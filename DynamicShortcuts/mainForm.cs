using System;
using System.IO;
using System.Windows.Forms;

namespace DynamicShortcutsTheory
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createNewIcon("iCloud Calendar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            readLinkToFile("iCloud Calendar");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateIcon("iCloud Calendar", numericUpDown1.Value.ToString());
        }


        //Create init icon
        private void createNewIcon(string shortcutName)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            using (StreamWriter writer = new StreamWriter(deskDir + "\\" + shortcutName + ".url"))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=https://www.icloud.com/calendar/");
                writer.WriteLine("IconIndex=0");
                string icon = @"C:\Users\lohre\Code Projects\DynamicShortcutsTheory\DynamicShortcutsTheory\icons\" + numericUpDown1.Value.ToString() + ".ico";
                writer.WriteLine("IconFile=" + icon);
                writer.WriteLine("HotKey=0");
                writer.WriteLine("IDList =");
                writer.Close();
            }
        }

        private void updateIcon(string shortcutName, string iconIndex)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string newIconPath = @"IconFile=C:\Users\lohre\Desktop\Dynamic Shortcuts\icons\" + iconIndex + ".ico";

            lineChanger(newIconPath, deskDir + "\\" + shortcutName + ".url", 4);

            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\clearIcons.cmd");
            readLinkToFile("iCloud Calendar");
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
                writer.Close();
            }

        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
