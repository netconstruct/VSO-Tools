using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using CloneBuildDefinitionApp.Core;
using Microsoft.VisualStudio.Services.Common;

namespace CloneBuildDefinitionApp
{
    public partial class CredentialsForm : Form
    {
        private readonly ProjectCollectionService _collectionService = new ProjectCollectionService();
        private readonly ProjectService _projectService = new ProjectService();

        public CredentialsForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtAccessToken.Text = ConfigurationManager.AppSettings.Get("VSTS.AccessToken");
            txtHostName.Text = ConfigurationManager.AppSettings.Get("VSTS.HostName");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var accessToken = txtAccessToken.Text.Trim();
            var hostName = txtHostName.Text.Trim();

            if (string.IsNullOrWhiteSpace(hostName))
            {
                MessageBox.Show("Enter a hostname.");
                return;
            }

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                MessageBox.Show("Enter an access token.");
                return;
            }

            FormContext.Current.HostName = hostName;
            FormContext.Current.Credentials = CreateCredentials(accessToken);

            FormContext.Current.Projects = _projectService.GetProjects();

            if (FormContext.Current.Projects == null || FormContext.Current.Projects.Any() == false)
            {
                MessageBox.Show("Could not connect.");
                return;
            }

            var mainForm = new MainForm
            {
                Location = Location,
                StartPosition = FormStartPosition.Manual
            };

            mainForm.FormClosed += (o, args) => Show();

            mainForm.Show();

            Hide();
        }

        private static VssBasicCredential CreateCredentials(string accessToken)
        {
            return new VssBasicCredential(string.Empty, accessToken);
        }
    }
}