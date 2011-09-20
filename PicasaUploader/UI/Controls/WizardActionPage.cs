using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using PicasaUploader.Aspects;

namespace PicasaUploader.UI.Controls
{
    public class WizardActionPage : UserControl
    {
        public event EventHandler<EventArgs> InitializationStarting;
        public event EventHandler<EventArgs> InitializationComplete;
        public event EventHandler<EventArgs> ActionStarting;
        public event EventHandler<SuccessEventArgs> ActionCompleted;

        protected virtual Func<bool> Action {
            get { return null; }
        }

        public virtual string ActionText {
            get { return null; }
        }

        public virtual void Initialize()
        {
        }

        public Wizard Wizard { get; set; }

        /// <summary>
        /// Executes the specified action asynchronously.
        /// </summary>
        public void ExecuteActionAsync()
        {
            if (Action == null)
                return;

            OnActionStarting();
            Task<bool> task = new Task<bool>(this.Action);
            // on success
            task.ContinueWith(t  => {
                this.Invoke((MethodInvoker)delegate {
                    OnActionCompleted(new SuccessEventArgs(t.Result));
                });
            }, TaskContinuationOptions.None);

            task.Start();
        }

        [ExecuteOnUIThread]
        protected virtual void OnActionStarting()
        {
            if (ActionStarting != null)
                ActionStarting(this, EventArgs.Empty);
        }

        [ExecuteOnUIThread]
        protected virtual void OnActionCompleted(SuccessEventArgs args)
        {
            if (ActionCompleted != null)
                ActionCompleted(this, args);
        }

        [ExecuteOnUIThread]
        protected virtual void OnInitializationStarting()
        {
            if (InitializationStarting != null)
                InitializationStarting(this, EventArgs.Empty);
        }

        [ExecuteOnUIThread]
        protected virtual void OnInitializationComplete()
        {
            if (InitializationComplete != null)
                InitializationComplete(this, EventArgs.Empty);
        }
    }
}
