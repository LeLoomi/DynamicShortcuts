using System;
using System.Windows.Forms;

namespace DynamicShortcuts
{
    static class Program
    {
        [STAThread]
        //the initial starting point of the program; non GUI stuff has to be called here as this function also initiates the GUI
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();   //to get the start paramenters before any GUI is started

            for (int i = 0; i < args.Length; i++)   //cycles through all start parameters the program has recieved
            {
                if (args[i] == "-runfullbgservice" || args[i] == "runfullbgservice")     //if this argument is passed, the program will run no GUI in the BG, only updating the icons
                {
                    DynSFunctionality.fullRun(Properties.Settings.Default.savedShotcutPath);
                    return; //used to exit out and finish the program directly after the icon update
                }
            }

            //this is generated by WinForms and starts the GUI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}
