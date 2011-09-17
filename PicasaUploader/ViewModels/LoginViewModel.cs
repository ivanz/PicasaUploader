using System;
using System.Collections.Generic;
using System.Linq;
using PicasaUploader.Properties;
using PicasaUploader.Commands;

namespace PicasaUploader.ViewModels
{
    public class LoginViewModel
    {
        private readonly IMediaUploadService _controller;

        public LoginViewModel(IMediaUploadService uploadService)
        {
            if (uploadService == null)
                throw new ArgumentNullException("uploadService", "uploadService is null.");

            _controller = uploadService;
            this.LoginCommand = new LoginCommand(uploadService);
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberCredentials { get; set; }

        protected IMediaUploadService UploadService
        {
            get { return _controller; }
        }

        public LoginCommand LoginCommand { get; private set; }

        public void SaveCredentials()
        {
            if (String.Compare(Settings.Default.Username, string.Empty, false) == 0)
                Settings.Default.Username = CryptoStringUtil.EncryptString(Username);

            if (String.Compare(Settings.Default.Password, string.Empty, false) == 0)
                Settings.Default.Password = CryptoStringUtil.EncryptString(Password);

            Settings.Default.Save();
        }

        public void PurgeCredentials()
        {
            Settings.Default.Username = string.Empty;
            Settings.Default.Password = string.Empty;
            Settings.Default.Save();
        }

        private void LoadCredentials()
        {
            if (Settings.Default.Username != string.Empty) {
                Username = CryptoStringUtil.DecryptString(Settings.Default.Username);
                RememberCredentials = true;
            }

            if (Settings.Default.Password != string.Empty) {
                Password = CryptoStringUtil.DecryptString(Settings.Default.Password);
                RememberCredentials = true;
            }
        }
    }
}
