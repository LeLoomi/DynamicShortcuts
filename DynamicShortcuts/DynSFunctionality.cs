// +-----------------------------------------------------------------------------------------------+
// | This is the core part of the program, all base logic and image gen etc. goes into this class! |
// +-----------------------------------------------------------------------------------------------+

using System;
using System.Diagnostics;   //for running the cmd file
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace DynamicShortcuts
{
    /// <summary>
    /// This class provides the core codebase for all functions of DynamicShortcuts.
    /// </summary>
    public static class DynSFunctionality
    {
        //call this function to run a complete background check and, if needed, update
        public static void fullRun(string filePath)
        {
            if (!iconUpToDate(filePath))
            {
                clearCache();
                generateIcon();
                updateIcon(filePath);
            }
        }


        //this function generates the icon from scratch
        public static void generateIcon()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();    //container to import custom font into
            pfc.AddFontFile(AppDomain.CurrentDomain.BaseDirectory + @"\MYRIADPRO-REGULAR.otf"); //read the actual font to the family
            Font firstCustomFont = new Font(pfc.Families[0], 55, FontStyle.Regular);    //create the two fonts (2 sizes) from the famlily
            Font secondCustomFont = new Font(pfc.Families[0], 115, FontStyle.Regular);

            StringFormat stringFormat = new StringFormat();         //StringFormat to centre the texts
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;


            string originalPNGPath = AppDomain.CurrentDomain.BaseDirectory + @"\iconbase.png";   //init image file path to make the icons out of


            string firstText = DateTime.Now.ToString("ddd").ToUpper();     //3 letter weekday text
            string secondText = DateTime.Now.ToString("dd");    //2 digit day of month text

            //set the text locations, these only work for an 256² image!
            PointF firstLocation = new PointF(128f, 70f);
            PointF secondLocation = new PointF(128f, 175f);


            string cachePath = AppDomain.CurrentDomain.BaseDirectory + @"\cache\";  //just for simplicity defined here
            Bitmap finishedBitmap;  //defined here to be used in using and after
            
            using (Bitmap bitmap = (Bitmap)Image.FromFile(originalPNGPath))    //load the image file
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

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\cache\"))  //check if cache directory exists
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\cache\");  //if not, create it


            int[] sizes = new int[] { 256, 128, 64, 32, 16};    //all the needed png sizes, after that we save the correct size for each of them by cycling through
            foreach (int size in sizes)
            {
                Bitmap png = new Bitmap(finishedBitmap, new Size(size, size));
                png.Save(cachePath + size + ".png");
            }

            //read all the sizes to memory
            using (var png256 = (Bitmap)Image.FromFile(cachePath + "256.png"))
            using (var png128 = (Bitmap)Image.FromFile(cachePath + "128.png"))
            using (var png64 = (Bitmap)Image.FromFile(cachePath + "64.png"))
            using (var png32 = (Bitmap)Image.FromFile(cachePath + "32.png"))
            using (var png16 = (Bitmap)Image.FromFile(cachePath + "16.png"))
             
            //open the stream / result ico path
            using (var stream = new FileStream(cachePath + dailyFileName() + ".ico", FileMode.OpenOrCreate))  //open filestream to the ico save path (application location)
            {
                IconFactory.SavePngsAsIcon(new[] { png256, png128, png64, png32, png16 }, stream);  //use IconFactory to put them all into an ico at the cache folder, marked with the correct daily name
            }
        }


        //this function updates the shortcut raw to set the new ico path
        public static void updateIcon(string filePath)
        {
            string updatedLine = "IconFile=" + AppDomain.CurrentDomain.BaseDirectory + @"\cache\" + dailyFileName() + ".ico";   //set the new line to be the correct filename

            lineChanger(updatedLine, filePath, 3);  //rewrite the shortcut content for the icon path
            lineChanger("IconIndex=0", filePath, 4); //rewrites the icon index just in case

            using (Process reloader = new Process())    //use Diagnostics.Process to launch the explorer & icons cache reset cmd file
            {
                reloader.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;     //do not show cmd promt on screen
                reloader.StartInfo.FileName = (AppDomain.CurrentDomain.BaseDirectory + @"\clearIcons.cmd"); //set process to start to be the cmd file
                reloader.Start();   //launch the reset cmd file
            }
        }


        //deletes all files in the cache folder
        private static void clearCache()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\cache\"))  //check if cache directory exists
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\cache\");  //if not, create it

            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\cache\");

            foreach (FileInfo file in dir.GetFiles())   //delete all files
            {
                file.Delete();
            }
            foreach (DirectoryInfo folder in dir.GetDirectories())  //delete all folders and substuff
            {
                folder.Delete(true);
            }
        }


        //this bool returns true if the icon is currently up to date (via file name check)
        public static bool iconUpToDate(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();    //read the current shortcut data to memory

                if (content.Contains(dailyFileName()))       //check if the shortcut contains the correct name, using dailyFileName() helper
                {
                    return true;    //if the contains return true then the icon is up to date
                }
                else return false;  //if the contains returns false then we need to update the icon
            }
        }


        //helper function to centralize the naming of the ico file, return the up to date core filename (e.g. "290721-Do"), no extension!
        private static string dailyFileName()
        {
            string tmp = DateTime.Now.ToString("ddMMyy") + "-" + DateTime.Now.ToString("ddd");  //puzzle the filename together
            return tmp; //return the name
        }


        //this function updates a specific line in a document, used to update the raw content of the shortcut. Taken from https://stackoverflow.com/a/35496185
        private static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
