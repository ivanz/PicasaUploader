//
// Copyright (c) 2009 Ivan Zlatev <ivan@ivanz.com>
//
// Authors:
//	Ivan Zlatev <ivan@ivanz.com>
//
// License: MIT/X11 - See LICENSE.txt
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Google.GData.Photos;
using Google.GData.Client;
using PicasaUploader.Services;

namespace PicasaUploader
{
    static class Program
    {
        public static IUIDispatcher UIDispatcher { get; private set; }

        [STAThread]
        static void Main(string[] args)
        {
            //try {
            //    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form mainForm = new PicasaUploaderForm(args);
                UIDispatcher = (IUIDispatcher)mainForm;
                Application.Run(mainForm);
            //} catch (Exception e) {
            //    UnhandledExceptionHandler(e);
            //}
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception && !e.IsTerminating)
                UnhandledExceptionHandler((Exception)e.ExceptionObject);
        }

        static void UnhandledExceptionHandler(Exception e)
        {
            DialogResult result = MessageBox.Show("The following unhandled exception occurred. Would you like to continue? " + Environment.NewLine +
                        Environment.NewLine + e.ToString(), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                Application.Run(new PicasaUploaderForm());
        }
    }
}
