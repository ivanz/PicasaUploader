using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PicasaUploader.Utilities
{
    public static class MimeTypeUtil
    {
        // TODO: Make this use a hashtable/dictionary internally
        public static string GetMimeType(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentException("fileName is null or empty.", "fileName");

            string extension = Path.GetExtension(fileName).ToLower();
            if (String.Compare(extension, ".gif", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "image/gif";
            else if (String.Compare(extension, ".jpeg", StringComparison.InvariantCultureIgnoreCase) == 0 ||
                 String.Compare(extension, ".jpg", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "image/jpeg";
            else if (String.Compare(extension, ".png", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "image/png";
            else if (String.Compare(extension, ".bmp", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "image/bmp";
            else if (String.Compare(extension, ".avi", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "video/avi";
            else if (String.Compare(extension, ".mp4", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "video/mp4";
            else if (String.Compare(extension, ".mov", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "video/quicktime";
            else if (String.Compare(extension, ".mpeg", StringComparison.InvariantCultureIgnoreCase) == 0 ||
                 String.Compare(extension, ".mpg", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "video/mpeg";
            else if (String.Compare(extension, ".asf", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "video/x-ms-asf";
            else if (String.Compare(extension, ".wmv", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "video/mp4";
            else if (String.Compare(extension, ".3gp", StringComparison.InvariantCultureIgnoreCase) == 0)
                return "video/3gpp";
            return null;
        }
    }
}
