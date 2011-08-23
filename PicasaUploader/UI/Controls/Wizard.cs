using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicasaUploader.UI.Controls
{
    public partial class Wizard : UserControl
    {
        public Wizard()
        {
            InitializeComponent();
        }

        public event EventHandler<WizardPageChangedEventArgs> PageChanged;

        public void AddPage(WizardActionPage page)
        {
            page.Wizard = this;

            TabPage tab = new TabPage();
            tab.Controls.Add(page);
            page.Dock = DockStyle.Fill;

            pagesTabs.TabPages.Add(tab);
            if (pagesTabs.TabCount == 1)
                page.Initialize();
        }

        public void Next()
        {
            WizardActionPage old = CurrentPage;
            pagesTabs.SelectedIndex = Math.Min(pagesTabs.SelectedIndex + 1, pagesTabs.TabCount);
            OnCurrentPageChanged(old);
        }

        public void Previous()
        {
            WizardActionPage old = CurrentPage;
            pagesTabs.SelectedIndex = Math.Max(pagesTabs.SelectedIndex - 1, 0);
            OnCurrentPageChanged(old);
        }

        public void GoTo<TPage>() where TPage : WizardActionPage
        {
            WizardActionPage old = CurrentPage;

            foreach (TabPage tabPage in pagesTabs.TabPages) {
                WizardActionPage actionPage = tabPage.Controls[0] as WizardActionPage;
            	if (typeof(TPage).IsAssignableFrom(actionPage.GetType())) {
                    pagesTabs.SelectedTab = tabPage;
                    OnCurrentPageChanged(old);
                    break;
                }
            }
        }

        private void OnCurrentPageChanged(WizardActionPage oldPage)
        {
            if (PageChanged != null)
                PageChanged(this, new WizardPageChangedEventArgs(oldPage, CurrentPage));

            if (CurrentPage != null)
                CurrentPage.Initialize();
        }

        public WizardActionPage CurrentPage {
            get
            {
                if (pagesTabs.TabCount > 0)
                    return (WizardActionPage)pagesTabs.SelectedTab.Controls[0];

                return null;
            }
        }

        public bool IsOnFirstPage {
            get { return pagesTabs.SelectedIndex == 0; }
        }

        public bool IsOnLastPage {
            get { return pagesTabs.SelectedIndex == pagesTabs.TabCount; }
        }
    }
}
