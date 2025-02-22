﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace LegacyOJPLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists("config.dat"))
            {
                Application.Run(new frmFirst());
            }
            else
            {
                FileStream file = new FileStream("config.dat", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);
                string gamePath = sr.ReadLine();
                string autoLaunch = sr.ReadLine();
                bool auto = false;
                if (autoLaunch == "1")
                    auto = true;
                sr.Close();
                Application.Run(new frmMain(true, gamePath,auto));
            }
        }
    }
}
