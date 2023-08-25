﻿using System;
using System.IO;
using System.Windows.Forms;

namespace _3d_graphics_app
{
  static class Program
  {
    private static string _modelFilesDirectory =
      Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\")) + "/Models/ObjectFiles/";
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
  }
}
