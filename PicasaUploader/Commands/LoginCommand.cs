using System;
using System.Collections.Generic;
using System.Linq;
using PicasaUploader.Services;
using PicasaUploader.Properties;

namespace PicasaUploader.Commands
{
    public class LoginCommand
    {
        public LoginCommand (IMediaUploadService uploadService)
        {
            UploadService = uploadService;
        }

        private IMediaUploadService UploadService { get; set; }

        public bool Login(string username, string password)
        {
            return UploadService.Login(username, password);
        }
    }
}
