//
// Copyright (c) 2009 Ivan N. Zlatev <contact@i-nz.net>
//
// Authors:
//	Ivan N. Zlatev <contact@i-nz.net>
//
// License: MIT/X11 - See LICENSE.txt
//

using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace PicasaUploader
{
	class NoCheckCertificatePolicy : ICertificatePolicy
	{
		#region ICertificatePolicy Members

		public bool CheckValidationResult (ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
		{
			return true;
		}

		#endregion
	}
}
