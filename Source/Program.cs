﻿using System;
using System.Windows.Forms;
using System.Threading;

namespace JeutieControl
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
        {
            bool instanceCountOne = false;
 
            using (Mutex mtex = new Mutex(true, "MyRunningApp", out instanceCountOne))
            {
                if (instanceCountOne)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run((Form) new Form1());
                    mtex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show(
                        "An application instance is already running !",
                        "Jeuties Server Restarter - Notice",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }
  }
}
