using System.Collections.Generic;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.Common;

namespace CloneBuildDefinitionApp.Core
{
    public class FormContext
    {
        public IEnumerable<BuildDefinitionReference> BuildDefinitions { get; set; }
        public VssBasicCredential Credentials { get; set; }

        public string HostName { get; set; }

        public IEnumerable<TeamProjectReference> Projects { get; set; }

        #region Singleton

        private static FormContext _current;

        public static FormContext Current => _current ?? (_current = new FormContext());

        #endregion
    }
}