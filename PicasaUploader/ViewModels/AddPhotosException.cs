using System;
using System.Collections.Generic;
using System.Linq;

namespace PicasaUploader.ViewModels
{
    public class AddPhotosException : Exception
    {
        public AddPhotosException(string message) : base (message)
        {
        }

        public List<string> UnsupportedFiles { get; set; }
        public List<string> OversizedFiles { get; set; }
        public List<string> AlbumCapacityExceedingFiles { get; set; }
    }
}
