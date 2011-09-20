using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PicasaUploader.UI.Controls;
using PicasaUploader.Commands;
using PicasaUploader.Services;
using PicasaUploader.ViewModels;
using System.Threading;

namespace PicasaUploader.UI.WizardPages
{
    internal partial class LoginPage : WizardActionPage
    {
        private readonly ITaskProgressMonitor _progressMonitor;
        private readonly LoginViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(LoginViewModel loginPageViewModel, ITaskProgressMonitor progressMonitor) : this()
        {
            if (loginPageViewModel == null)
                throw new ArgumentNullException("loginPageViewModel", "loginPageViewModel is null.");
            if (progressMonitor == null)
                throw new ArgumentNullException("progressMonitor", "progressMonitor is null.");

            _viewModel = loginPageViewModel;
            _progressMonitor = progressMonitor;
        }

        public override void Initialize()
        {
            usernameTextBox.Select();
            if (ViewModel.RememberCredentials)
                base.ExecuteActionAsync();
        }

        private void SyncModelWithUI()
        {
            ViewModel.Username = this.usernameTextBox.Text;
            ViewModel.Password = this.passwordTextBox.Text;
            ViewModel.RememberCredentials = this.rememberCheckBox.Checked;
        }

        protected override Func<CancellationToken, bool> Action
        {
            get { return (cancellationToken) => { return DoLogin(); }; }
        }

        public override bool SupportsCancellation
        {
            get { return false; }
        }

        private bool DoLogin()
        {
            ProgressMonitor.StartTask(1, "Logging In");

            SyncModelWithUI();

            if (!ViewModel.RememberCredentials)
                ViewModel.PurgeCredentials();
            else
                ViewModel.SaveCredentials();

            bool success = ViewModel.LoginCommand.Login(ViewModel.Username, ViewModel.Password);
            if (!success) {
                MessageBox.Show("Invalid username/password or no Internet connection available.", "Login Failed",
                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            ProgressMonitor.CompleteTask();

            return success;
        }

        private ITaskProgressMonitor ProgressMonitor
        {
            get { return _progressMonitor; }
        }

        private LoginViewModel ViewModel
        {
            get { return _viewModel; }
        }

        private void passwordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter) {
                ExecuteActionAsync();
                e.Handled = true;
            }
            e.Handled = false;
        }
    }
}
