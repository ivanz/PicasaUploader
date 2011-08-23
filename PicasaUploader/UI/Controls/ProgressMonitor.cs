using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PicasaUploader.Services;
using PicasaUploader.Aspects;

namespace PicasaUploader.UI.Controls
{
    public partial class ProgressMonitor : UserControl, ITaskProgressMonitor
    {
        private bool _running;
        private const string _readyText = "Ready";

        public ProgressMonitor()
        {
            InitializeComponent();
        }


        #region IProgressMonitor Members

        public void StartTask(int stepsCount, string description)
        {
            AssertNoTaskRunning();
            BeginProgress(stepsCount, description);
        }

        private string StatusText
        {
            set { taskDescription.Text = value; }
        }

        [ExecuteOnUIThread]
        private void BeginProgress(int stepsCount, string description)
        {
            progressBar.Value = 0;
            progressBar.Maximum = stepsCount;
            if (stepsCount == 1)
                progressBar.Style = ProgressBarStyle.Marquee;
            else
                progressBar.Style = ProgressBarStyle.Continuous;

            StatusText = description;

            _running = true;
            if (TaskStarted != null)
                TaskStarted(this, EventArgs.Empty);
        }

        private void AssertNoTaskRunning()
        {
            if (IsTaskRunning)
                throw new InvalidOperationException("A task is already running.");
        }

        private void AssertTaskRunning()
        {
            if (!IsTaskRunning)
                throw new InvalidOperationException("No task is running.");
        }

        [ExecuteOnUIThread]
        public void Step(string description)
        {
            AssertTaskRunning();

            progressBar.Value = progressBar.Value + 1;
            StatusText = description;
        }

        [ExecuteOnUIThread]
        public void CompleteTask()
        {
            AssertTaskRunning();

            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Continuous;
            ResetStatusText();

            _running = false;

            if (TaskCompleted != null)
                TaskCompleted(this, EventArgs.Empty);
        }

        private void ResetStatusText()
        {
            StatusText = _readyText;
        }

        public bool IsTaskRunning
        {
            get { return _running; }
        }

        public event EventHandler<EventArgs> TaskCompleted;
        public event EventHandler<EventArgs> TaskStarted;

        #endregion
    }
}
