using System;
using System.Collections.Generic;
using Microsoft.TeamFoundation.Build.WebApi;

namespace CloneBuildDefinitionApp.Core
{
    internal class BuildDefinitionService
    {
        public BuildDefinition CreateBuildDefinition(Guid projectId, BuildDefinition definition)
        {
            var uri = new Uri($"https://{FormContext.Current.HostName}/");
            var client = new BuildHttpClient(uri, FormContext.Current.Credentials);
            var task = client.CreateDefinitionAsync(definition, projectId);
            task.Wait();
            return task.Result;
        }

        public BuildDefinition GetBuildDefinition(Guid projectId, int definitionId)
        {
            var uri = new Uri($"https://{FormContext.Current.HostName}/");
            var client = new BuildHttpClient(uri, FormContext.Current.Credentials);
            var task = client.GetDefinitionAsync(projectId, definitionId);
            task.Wait();
            return task.Result;
        }

        public IEnumerable<BuildDefinitionReference> GetBuildDefinitions(Guid projectId)
        {
            var uri = new Uri($"https://{FormContext.Current.HostName}/");
            var client = new BuildHttpClient(uri, FormContext.Current.Credentials);
            var task = client.GetDefinitionsAsync(projectId);
            task.Wait();
            return task.Result;
        }
    }
}