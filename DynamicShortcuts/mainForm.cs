﻿// +----------------------------------------------------------------------------------------------+
// | This is the GUI part of the program, all base logic and such goes into DynSFunctionality.cs! |
// +----------------------------------------------------------------------------------------------+

using System;
using System.Windows.Forms;


namespace DynamicShortcuts
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }


        //initiate full run
        private void fullRunButton_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.savedShotcutPath != "")
                DynSFunctionality.fullRun(Properties.Settings.Default.savedShotcutPath);
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "weblink files (*.url)|*url";   //only allow shortcuts
                openFileDialog.Title = "Select Shortcut";
                if (Properties.Settings.Default.savedShotcutPath != "") //check saved path for value
                    openFileDialog.InitialDirectory = Properties.Settings.Default.savedShotcutPath; //if same was saved then set this as start
                else openFileDialog.InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString();   //else just go to the desktop

                openFileDialog.ShowDialog();    //show select dialog
                pathTextbox.Text = openFileDialog.FileName; //set the selected file to the textbox
            }
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save(); //save the path input from the form into settings
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://GitHub.com/LeLoomi");
        }
    }
}
