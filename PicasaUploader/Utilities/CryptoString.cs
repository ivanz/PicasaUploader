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
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace PicasaUploader
{
	class CryptoStringUtil
	{
		static byte[] _entropy = System.Text.Encoding.Default.GetBytes ("this is a salt !@#$&%$14232345");

		public static string EncryptString (string input)
		{
			byte[] encryptedData = ProtectedData.Protect (
			    Encoding.Default.GetBytes (input),
			    _entropy,
			    DataProtectionScope.CurrentUser);
			return Convert.ToBase64String (encryptedData);
		}

		public static string DecryptString (string encryptedData)
		{
			try {
				byte[] decryptedData = ProtectedData.Unprotect (
				    Convert.FromBase64String (encryptedData),
				    _entropy,
				    DataProtectionScope.CurrentUser);
				return Encoding.Default.GetString (decryptedData);
			} catch {
				return String.Empty;
			}
		}
	}
}
