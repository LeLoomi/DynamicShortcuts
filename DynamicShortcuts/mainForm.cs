using System;
using System.Diagnostics;   //to launch cmd line
using System.Drawing;       //generating the icons
using System.Drawing.Text;        //for the custom font
using System.IO;        //to write read the shortcut
using System.Windows.Forms;

namespace DynamicShortcutsTheory
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            createNewShortcut("iCloud Calendar");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            updateShortcut("iCloud Calendar", numericUpDown1.Value.ToString());
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            readLinkToFile("iCloud Calendar");
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            generateIcon();
        }


        //Create init icon
        private void createNewShortcut(string shortcutName)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + shortcutName + ".url"))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=https://www.icloud.com/calendar/");
                writer.WriteLine("IconIndex=0");
                string iconpath = AppDomain.CurrentDomain.BaseDirectory + @"icons\" + numericUpDown1.Value.ToString() + ".ico";
                writer.WriteLine("IconFile=" + iconpath);
                writer.WriteLine("HotKey=0");
                writer.WriteLine("IDList =");
            }
        }

        private void updateShortcut(string shortcutName, string iconIndex)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string newLine = "IconFile=" + AppDomain.CurrentDomain.BaseDirectory + @"icons\" + iconIndex + ".ico";

            lineChanger(newLine, deskDir + "\\" + shortcutName + ".url", 4);

            using (Process reloader = new Process())
            {
                reloader.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                reloader.StartInfo.FileName = (AppDomain.CurrentDomain.BaseDirectory + @"\clearIcons.cmd");
                reloader.Start();
            }

        }

        //read icon to text file
        private void readLinkToFile(string shortcutName)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            using (StreamReader reader = new StreamReader(deskDir + "\\" + shortcutName + ".url"))
            {
                string content = reader.ReadToEnd();

                StreamWriter writer = new StreamWriter(deskDir + "\\" + shortcutName + ".log");
                writer.WriteLine(content);
            }

        }

        private void generateIcon()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();    //import custom font
            pfc.AddFontFile(AppDomain.CurrentDomain.BaseDirectory + @"\MYRIADPRO-REGULAR.OTF");
            Font firstCustomFont = new Font(pfc.Families[0], 55, FontStyle.Regular);
            Font secondCustomFont = new Font(pfc.Families[0], 115, FontStyle.Regular);

            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;


            string weekday = DateTime.Now.ToString("ddd");  //get 3 letter weekday name
            string saveName = DateTime.Now.ToString("ddMMyy") + "-" + weekday;   //get file name pattern
            string savePath = @"C:\Users\lohre\Desktop\";       //temp save path


            string openImagePath;   //init image file path, outside of using to be kept after

            using (OpenFileDialog openFileDialog = new OpenFileDialog())    //load icon base image
            {
                openFileDialog.Filter = "PNG images|*.png;*.PNG";
                openFileDialog.ShowDialog();
                openImagePath = openFileDialog.FileName;
            }

            string firstText = DateTime.Now.ToString("ddd").ToUpper();     //3 letter weekday text
            string secondText = DateTime.Now.ToString("dd");    //2 digit day of month text


            PointF firstLocation = new PointF(128f, 70f);
            PointF secondLocation = new PointF(128f, 175f);

            
            Bitmap finishedBitmap;
            using (var bitmap = (Bitmap)Image.FromFile(openImagePath))//load the image file
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

            finishedBitmap.Save(savePath + @"\" + saveName + ".png");  //save the image file temp


            Icon ico = Icon.FromHandle(finishedBitmap.GetHicon());  //convert bmp to ico
            FileStream fs = new FileStream(savePath + @"\" + saveName + ".ico", FileMode.OpenOrCreate);
            ico.Save(fs);
            fs.Close();

            ico.Dispose();   //clear memory
            finishedBitmap.Dispose();
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
