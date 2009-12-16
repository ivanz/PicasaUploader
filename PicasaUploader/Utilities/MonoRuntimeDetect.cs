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
using System.Text;

namespace PicasaUploader
{
	static class MonoRuntimeDetect
	{
		public static bool IsRunningOnMono
		{
			get { return Type.GetType ("Mono.Runtime") != null; }
		}
	}
}
