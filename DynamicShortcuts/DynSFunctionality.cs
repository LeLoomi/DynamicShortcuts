// +-----------------------------------------------------------------------------------------------+
// | This is the core part of the program, all base logic and image gen etc. goes into this class! |
// +-----------------------------------------------------------------------------------------------+

using System;
using System.IO;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;       //for running the cmd file
using ImageMagick;

namespace DynamicShortcuts
{
    public static class DynSFunctionality
    {
        //call this function to run a complete background check and, if needed, update
        public static void fullRun(string filePath)
        {
            //if (!iconUpToDate(filePath)) currently disabled for testing
            //{
                Console.WriteLine("DynamicShortcuts: Icon is out of date (" + filePath + ").");

                Console.WriteLine("DynamicShortcuts: Generating new icon with the name " + dailyFileName() + "(" + filePath + ")");
                generateIcon();

                Console.WriteLine("DynamicShortcuts: Updating the shortcut icon to '" + dailyFileName() + "' (" + filePath + ")");
                updateIcon(filePath);
            //}
            //else Console.WriteLine("fullRun completed, icon was up to date. No chanes made.");
        }



        public static void generateIcon()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();    //container to import custom font into
            pfc.AddFontFile(AppDomain.CurrentDomain.BaseDirectory + @"\MYRIADPRO-REGULAR.OTF"); //read the actual font to the family
            Font firstCustomFont = new Font(pfc.Families[0], 55, FontStyle.Regular);    //create the two fonts (2 sizes) from the famlily
            Font secondCustomFont = new Font(pfc.Families[0], 115, FontStyle.Regular);

            StringFormat stringFormat = new StringFormat();         //StringFormat to centre the texts
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;


            string weekday = DateTime.Now.ToString("ddd");  //get 3 letter weekday name
            string saveName = DateTime.Now.ToString("ddMMyy") + "-" + weekday;   //get file name pattern


            string originalPNGPath = AppDomain.CurrentDomain.BaseDirectory + @"\iconbase.png";   //init image file path

            /*using (OpenFileDialog openFileDialog = new OpenFileDialog())    //load icon base image
            {
                openFileDialog.Filter = "PNG images|*.png;*.PNG";
                openFileDialog.ShowDialog();
                originalPNGPath = openFileDialog.FileName;
            }*/

            string firstText = DateTime.Now.ToString("ddd").ToUpper();     //3 letter weekday text
            string secondText = DateTime.Now.ToString("dd");    //2 digit day of month text


            PointF firstLocation = new PointF(128f, 70f);
            PointF secondLocation = new PointF(128f, 175f);


            Bitmap finishedBitmap;
            using (var bitmap = (Bitmap)Image.FromFile(originalPNGPath))//load the image file
            {
                Bitmap resizedBitmap = new Bitmap(bitmap, new Size(256, 256));  //scale bitmap to fit win explorer 256²

                using (Graphics graphics = Graphics.FromImage(resizedBitmap))
                {
                    Brush dayBrush = new SolidBrush(Color.FromArgb(255, 254, 40, 41));
                    Brush dateBrush = new SolidBrush(Color.FromArgb(255, 30, 31, 30));

                    graphics.DrawString(firstText, firstCustomFont, dayBrush, firstLocation, stringFormat);       //here it all comes together and gets drawn
                    graphics.DrawString(secondText, secondCustomFont, dateBrush, secondLocation, stringFormat);
                }
                finishedBitmap = new Bitmap(resizedBitmap);
                resizedBitmap.Dispose();
            }
            
            

            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\" + saveName + ".ico", FileMode.OpenOrCreate); //open filestream to the ico save path (application location)

            ImageConverter imageConverter = new ImageConverter();
            byte[] byteBitmap = (byte[])imageConverter.ConvertTo(finishedBitmap, typeof(byte[]));

            using (MagickImage image = new MagickImage(byteBitmap))
            {
                image.Settings.SetDefine("auto-resize", "256,128,96,64,48,32,16");
                image.Settings.Format = MagickFormat.Icon;
                image.Write(fs);
            }

            fs.Close();     //clear memory
            finishedBitmap.Dispose();   //clear memory
        }


        //this function updates the shortcut raw to set the new ico path
        public static void updateIcon(string filePath)
        {
            string updatedLine = "IconFile=" + AppDomain.CurrentDomain.BaseDirectory + dailyFileName() + ".ico";   //set the new line to be the correct filename

            lineChanger(updatedLine, filePath, 3);  //rewrite the shortcut content for the icon path
            lineChanger("IconIndex=0", filePath, 4); //rewrites the icon index just in case

            using (Process reloader = new Process())    //use Diagnostics.Process to launch the explorer & icons cache reset cmd file
            {
                reloader.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;     //do not show cmd promt on screen
                reloader.StartInfo.FileName = (AppDomain.CurrentDomain.BaseDirectory + @"\clearIcons.cmd"); //set process to start to be the cmd file
                reloader.Start();   //launch the reset cmd file
            }
        }


        //this bool returns true if the icon is currently up to date (via file name check)
        public static bool iconUpToDate(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();    //read the current shortcut data to memory

                if(content.Contains(dailyFileName()))       //check if the shortcut contains the correct name, using dailyFileName() helper
                {
                    return true;    //if the contains return true then the icon is up to date
                }
                else return false;  //if the contains returns false then we need to update the icon
            }
        }


        //helper function to centralize the naming of the ico file, return the up to date core filename (e.g. "290721-Do"), no extension!
        public static string dailyFileName()
        {
            string tmp = DateTime.Now.ToString("ddMMyy") + "-" + DateTime.Now.ToString("ddd");  //puzzle the filename together
            return tmp; //return the name
        }


        //this function updates a specific line in a document, used to update the raw content of the shortcut. Taken from https://stackoverflow.com/a/35496185
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
