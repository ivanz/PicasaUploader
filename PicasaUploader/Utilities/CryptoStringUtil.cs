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
using System.Security.Cryptography;

namespace PicasaUploader
{
	class CryptoStringUtil
	{
		static byte[] _entropy = Encoding.Default.GetBytes ("this is a salt !@#$&%$14232345");

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
