using System;
using System.Linq;
using System.Windows.Forms;
using CloneBuildDefinitionApp.Core;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.Core.WebApi;

namespace CloneBuildDefinitionApp
{
    public partial class MainForm : Form
    {
        private readonly BuildDefinitionService _definitionService = new BuildDefinitionService();

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ddlBuildDefinition.DataSource = FormContext.Current.BuildDefinitions?.ToArray();
            ddlBuildDefinition.DisplayMember = "Name";
            ddlBuildDefinition.ValueMember = "Id";

            ddlDestinationProject.DataSource = FormContext.Current.Projects?.ToArray();
            ddlDestinationProject.DisplayMember = "Name";
            ddlDestinationProject.ValueMember = "Id";

            ddlSourceProject.DataSource = FormContext.Current.Projects?.ToArray();
            ddlSourceProject.DisplayMember = "Name";
            ddlSourceProject.ValueMember = "Id";
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            var sourceProject = ddlSourceProject.SelectedItem as TeamProjectReference;

            if (sourceProject == null)
            {
                MessageBox.Show("Select a source project.");
                return;
            }

            var definitionRef = ddlBuildDefinition.SelectedItem as BuildDefinitionReference;

            if (definitionRef == null)
            {
                MessageBox.Show("Select a definition.");
                return;
            }

            var destinationProject = ddlDestinationProject.SelectedItem as TeamProjectReference;

            if (destinationProject == null)
            {
                MessageBox.Show("Select a destination project.");
                return;
            }

            var definition = _definitionService.GetBuildDefinition(sourceProject.Id, definitionRef.Id);
            definition.Name = $"{definition.Name} (Clone)";
            definition.Project = null;

            _definitionService.CreateBuildDefinition(destinationProject.Id, definition);

            MessageBox.Show("Success");
        }

        private void ddlSourceProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBuildDefinition.SelectedItem = null;

            var definition = ddlSourceProject.SelectedItem as TeamProjectReference;

            if (definition == null)
            {
                return;
            }

            FormContext.Current.BuildDefinitions = _definitionService.GetBuildDefinitions(definition.Id);
            ddlBuildDefinition.DataSource = FormContext.Current.BuildDefinitions?.ToArray();
        }
    }
}