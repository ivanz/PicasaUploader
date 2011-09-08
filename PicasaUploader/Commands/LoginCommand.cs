using System;
using System.Collections.Generic;
using System.Linq;
using PicasaUploader.Services;
using PicasaUploader.Properties;

namespace PicasaUploader.Commands
{
    public class LoginCommand
    {
        public LoginCommand (IPicasaController picasa)
        {
            Picasa = picasa;
        }

        private IPicasaController Picasa { get; set; }

        public bool Login(string username, string password)
        {
            return Picasa.Login(username, password);
        }
    }
}
