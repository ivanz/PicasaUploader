using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PicasaUploader.ViewModels
{
    public class NewAlbumEditModel : IDataErrorInfo
    {
        public NewAlbumEditModel()
        {
            Date = DateTime.Now;
        }

        public string Title
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public bool Public
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        #region IDataErrorInfo Members

        public string Error
        {
            get { return String.Empty; }
        }

        // TODO: This should be declarative rather than programatic
        public string this[string columnName]
        {
            get {
                switch(columnName) {
                    case "Title":
                        if (String.IsNullOrWhiteSpace(Title))
                            return "Title is required.";
                        break;
                }
                return String.Empty;
            }
        }

        #endregion
    }
}
