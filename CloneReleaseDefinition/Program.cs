using System;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.ReleaseManagement.WebApi;
using Microsoft.VisualStudio.Services.ReleaseManagement.WebApi.Clients;

namespace CloneReleaseDefinition
{
    internal class Program
    {
        private static void CloneRelease(string hostName, int releaseDef, string accessToken, string sourceProject, string destinationProject)
        {
            var releaseClient = CreateClient(hostName, accessToken);

            var definition = GetReleaseDefinition(releaseDef, sourceProject, releaseClient);

            definition.Name = definition.Name + "Clone";

            var ress = releaseClient.CreateReleaseDefinitionAsync(definition, destinationProject);
            ress.Wait();
        }

        private static ReleaseHttpClient CreateClient(string hostName, string accessToken)
        {
            var collectionUri = new Uri($"https://{hostName}/DefaultCollection", UriKind.Absolute);
            var cred = new VssBasicCredential(string.Empty, accessToken);
            var releaseClient = new ReleaseHttpClient(collectionUri, cred);
            return releaseClient;
        }

        private static ReleaseDefinition GetReleaseDefinition(int releaseDef, string sourceProject, ReleaseHttpClient releaseClient)
        {
            var definitionAsync = releaseClient.GetReleaseDefinitionAsync(sourceProject, releaseDef);
            definitionAsync.Wait();
            var definition = definitionAsync.Result;
            return definition;
        }

        private static void Main(string[] args)
        {
            var hostName = args[0];
            var releaseDef = int.Parse(args[1]);
            var sourceProject = args[2];
            var destinationProject = args[3];
            var accessToken = args[4];

            try
            {
                CloneRelease(hostName, releaseDef, accessToken, sourceProject, destinationProject);
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