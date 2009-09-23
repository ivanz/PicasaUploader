//
// Copyright (c) 2009 Ivan N. Zlatev <contact@i-nz.net>
//
// Authors:
//	Ivan N. Zlatev <contact@i-nz.net>
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

namespace PicasaUploader
{
	static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			try {
				AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler (CurrentDomain_UnhandledException);
				Application.EnableVisualStyles ();
				Application.SetCompatibleTextRenderingDefault (false);
				Application.Run (new PicasaUploaderForm (args));
			} catch (Exception e) {
				UnhandledExceptionHandler (e);
			}
		}

		static void CurrentDomain_UnhandledException (object sender, UnhandledExceptionEventArgs e)
		{
			if (e.ExceptionObject is Exception)
				UnhandledExceptionHandler ((Exception)e.ExceptionObject);
		}

		static void UnhandledExceptionHandler (Exception e)
		{
			DialogResult result = MessageBox.Show ("The following unhandled exception occurred. Would you like to continue? " + Environment.NewLine + 
						Environment.NewLine + e.ToString (), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
				Application.Run (new PicasaUploaderForm ());
		}
	}
}
