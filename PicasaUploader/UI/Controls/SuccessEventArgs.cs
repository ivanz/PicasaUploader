using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicasaUploader.UI.Controls
{
    public class SuccessEventArgs : EventArgs
    {
        public SuccessEventArgs(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }
    }
}
