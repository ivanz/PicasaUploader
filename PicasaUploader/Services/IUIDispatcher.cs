using System;
using System.Collections.Generic;
using System.Linq;

namespace PicasaUploader.Services
{
    interface IUIDispatcher
    {
        void InvokeOnUIThread(Action action);
    }
}
