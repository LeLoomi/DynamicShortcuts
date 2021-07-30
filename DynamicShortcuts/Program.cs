﻿using System;
using System.Windows.Forms;

namespace DynamicShortcuts
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();   //to get the start paramenters before any GUI is started

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-runfullbgservice" || args[i] == "runfullbgservice")     //if this argument is passed, the program will run no GUI in the BG, only updating the icons
                {
                    DynSFunctionality.fullRun(Properties.Settings.Default.savedShotcutPath);
                    return; //used to exit out and finish the program directly after the icon update
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}
