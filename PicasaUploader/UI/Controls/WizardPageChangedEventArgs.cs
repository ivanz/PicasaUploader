using System;
using System.Collections.Generic;
using System.Linq;

namespace PicasaUploader.UI.Controls
{
    public class WizardPageChangedEventArgs : EventArgs
    {
        public WizardPageChangedEventArgs(WizardActionPage oldPage, WizardActionPage newPage)
        {
            NewPage = newPage;
            OldPage = oldPage;
        }

        public WizardActionPage OldPage { get; private set; }
        public WizardActionPage NewPage { get; private set; }
    }
}
