using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using PicasaUploader.Aspects;
using System.Threading;

namespace PicasaUploader.UI.Controls
{
    public class WizardActionPage : UserControl
    {
        public event EventHandler<EventArgs> InitializationStarting;
        public event EventHandler<EventArgs> InitializationComplete;
        public event EventHandler<EventArgs> ActionStarting;
        public event EventHandler<SuccessEventArgs> ActionCompleted;

        private CancellationTokenSource _cancelationSource;

        protected virtual Func<CancellationToken, bool> Action {
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
            _cancelationSource = new CancellationTokenSource();
            CancellationToken cancellationToken = _cancelationSource.Token;
            
            Task<bool> task = new Task<bool>(() => {
                return this.Action(cancellationToken);
            }, cancellationToken);

            // on success
            task.ContinueWith(t => {
                OnActionCompleted(new SuccessEventArgs(t.Result));
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            task.ContinueWith(t => {
                OnActionCompleted(new SuccessEventArgs(t.Result));
            }, TaskContinuationOptions.OnlyOnCanceled);

            task.Start();
        }

        public void CancelAction()
        {
            if (SupportsCancellation)
                _cancelationSource.Cancel();
        }

        public virtual bool SupportsCancellation
        {
            get { return false; }
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
