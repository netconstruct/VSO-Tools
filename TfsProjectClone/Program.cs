using System;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.VisualStudio.Services.Common;

namespace CloneBuildDefinition
{
    internal class Program
    {
        private static void CloneBuild(string hostName, int buildDef, string accessToken, string sourceProject, string destinationProject)
        {
            var buildClient = CreateClient(hostName, accessToken);

            var definition = GetBuildDefinition(buildDef, sourceProject, buildClient);

            definition.Name = definition.Name + "Clone";
            definition.Project = null;

            var ress = buildClient.CreateDefinitionAsync(definition, destinationProject);
            ress.Wait();
        }

        private static BuildHttpClient CreateClient(string hostName, string accessToken)
        {
            var collectionUri = new Uri($"https://{hostName}/DefaultCollection", UriKind.Absolute);
            var cred = new VssBasicCredential(string.Empty, accessToken);
            var buildClient = new BuildHttpClient(collectionUri, cred);
            return buildClient;
        }

        private static BuildDefinition GetBuildDefinition(int buildDef, string sourceProject, BuildHttpClientBase buildClient)
        {
            var definitionAsync = buildClient.GetDefinitionAsync(sourceProject, buildDef);
            definitionAsync.Wait();
            var definition = (BuildDefinition) definitionAsync.Result;
            return definition;
        }

        private static void Main(string[] args)
        {
            var hostName = args[0];
            var buildDef = int.Parse(args[1]);
            var sourceProject = args[2];
            var destinationProject = args[3];
            var accessToken = args[4];

            try
            {
                CloneBuild(hostName, buildDef, accessToken, sourceProject, destinationProject);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                foreach (var innerException in ex.InnerExceptions)
                {
                    Console.WriteLine($"Error: {innerException.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}