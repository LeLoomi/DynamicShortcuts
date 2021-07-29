// +----------------------------------------------------------------------------------------------+
// | This is the GUI part of the program, all base logic and such goes into DynSFunctionality.cs! |
// +----------------------------------------------------------------------------------------------+

using System;
using System.Diagnostics;   //to launch cmd line
using System.IO;        //to write read the shortcut
using System.Windows.Forms;


namespace DynamicShortcuts
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        
        private void generateInBackgroundButton_Click(object sender, EventArgs e)
        {
            DynSFunctionality.generateIcon();
        }
        private void fullRunButton_Click(object sender, EventArgs e)
        {
            DynSFunctionality.fullRun(@"C:\Users\lohre\Desktop\iCloud Calendar.url");
        }
    }
}
