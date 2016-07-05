using System;
using System.Collections.Generic;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.Common;

namespace CloneBuildDefinitionApp.Core
{
    public class ProjectService
    {
        public IEnumerable<TeamProjectReference> GetProjects()
        {
            var uri = new Uri($"https://{FormContext.Current.HostName}/");
            var client = new ProjectHttpClient(uri, FormContext.Current.Credentials);
            var result = client.GetProjects();
            result.Wait();
            return result.Result;
        }
    }
}