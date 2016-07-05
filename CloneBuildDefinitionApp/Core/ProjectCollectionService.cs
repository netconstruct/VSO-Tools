using System;
using System.Collections.Generic;
using Microsoft.TeamFoundation.Core.WebApi;

namespace CloneBuildDefinitionApp.Core
{
    public class ProjectCollectionService
    {
        public IEnumerable<TeamProjectCollectionReference> GetCollections()
        {
            var uri = new Uri($"https://{FormContext.Current.HostName}/");
            var client = new ProjectCollectionHttpClient(uri, FormContext.Current.Credentials);
            var result = client.GetProjectCollections();
            result.Wait();
            return result.Result;
        }
    }
}