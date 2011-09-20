using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PicasaUploader.Aspects;

namespace PicasaUploader.UI.Controls
{
    public partial class WizardActionBar : UserControl
    {
        private const string Next_Button_String = "Next";
        private const string Cancel_Button_String = "Cancel";
        private const string Cancelling_Button_String = "Cancelling..";


        private Wizard _wizard;
        private bool _actionExecuting = false;

        /// <summary>
        /// Do not use this constructor it's only here for the WinForms designer surface
        /// to be able to instantiate the control.
        /// </summary>
        public WizardActionBar()
        {
            InitializeComponent();
        }

        public WizardActionBar(Wizard wizard) : this()
        {
            Wizard = wizard;
        }

        private bool IsActionInProgress
        {
            get { return _actionExecuting; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Wizard Wizard
        {
            get { return _wizard; }
            set {
                if (_wizard != null)
                    _wizard.PageChanged -= OnWizardPageChanged;
                    
                _wizard = value;

                if (_wizard != null) {
                    _wizard.PageChanged += OnWizardPageChanged;
                    UpdateButtons();

                    if (_wizard.CurrentPage != null)
                        ConnectToPageEvents(Wizard.CurrentPage);
                }
            }
        }

        public void OnWizardPageChanged(object sender, WizardPageChangedEventArgs args)
        {
            UpdateButtons();
            DisconnectFromPageEvents(args.OldPage);
            ConnectToPageEvents(args.NewPage);
        }

        private void GoNext ()
        {
            if (Wizard.CurrentPage != null)
                Wizard.CurrentPage.ExecuteActionAsync();
        }

        private void ConnectToPageEvents(WizardActionPage actionPage)
        {
            if (actionPage == null)
                return;

            actionPage.ActionStarting += OnActionStarting;
            actionPage.ActionCompleted += OnActionCompleted;
            actionPage.InitializationStarting += OnInitializationStarting;
            actionPage.InitializationComplete += OnInitializationComplete;
        }

        private void DisconnectFromPageEvents(WizardActionPage actionPage)
        {
            if (actionPage == null)
                return;

            actionPage.ActionStarting -= OnActionStarting;
            actionPage.ActionCompleted -= OnActionCompleted;
            actionPage.InitializationStarting -= OnInitializationStarting;
            actionPage.InitializationComplete -= OnInitializationComplete;
        }

        private void UpdateButtons()
        {
            DisableButtons();

            WizardActionPage actionPage = Wizard.CurrentPage;
            if (actionPage != null) {
                this.nextButton.Text = actionPage.ActionText ?? Next_Button_String;
                nextButton.Enabled = true;
            }

            if (Wizard.IsOnFirstPage)
                this.backButton.Enabled = false;
            else
                this.backButton.Enabled = true;
        }

        [ExecuteOnUIThread]
        public void OnActionCompleted(object sender, SuccessEventArgs args)
        {
            this._actionExecuting = false;

            UpdateButtons();

            if (args.Success)
                Wizard.Next();
        }

        [ExecuteOnUIThread]
        private void OnInitializationStarting(object sender, EventArgs args)
        {
            DisableButtons();
        }

        [ExecuteOnUIThread]
        private void OnInitializationComplete(object sender, EventArgs args)
        {
            EnableButtons();
        }

        [ExecuteOnUIThread]
        private void OnActionStarting(object sender, EventArgs args)
        {
            DisableButtons();
            _actionExecuting = true;

            if (Wizard.CurrentPage.SupportsCancellation) {
                nextButton.Text = Cancel_Button_String;
                nextButton.Enabled = true;
            }
        }

        private void DisableButtons()
        {
            this.backButton.Enabled = false;
            this.nextButton.Enabled = false;
        }

        private void EnableButtons()
        {
            this.backButton.Enabled = true;
            this.nextButton.Enabled = true;
        }

        private void GoPrevious()
        {
            Wizard.Previous();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (IsActionInProgress)
                CancelCurrentAction();
            else
                GoNext();
        }

        private void CancelCurrentAction()
        {
            nextButton.Enabled = false;
            nextButton.Text = Cancelling_Button_String;
            Wizard.CurrentPage.CancelAction();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GoPrevious();
        }
    }
}
