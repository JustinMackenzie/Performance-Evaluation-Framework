using System;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleScenarioManager.Commands;
using MediatR;

namespace ConsoleScenarioManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    public class RemoveScenarioAssetCommandHandler : IAsyncRequestHandler<RemoveScenarioAssetCommand, int>
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<int> Handle(RemoveScenarioAssetCommand message)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{message.ServerUrl}/api/Scenario/{message.ScenarioId}/asset/{message.Tag}");
                string content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);

                return 0;
            }
        }
    }
}