using System;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleTrialSetManager.Commands;
using MediatR;

namespace ConsoleTrialSetManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="int" />
    public class RemoveScenarioFromTrialSetCommandHandler : IAsyncRequestHandler<RemoveScenarioFromTrialSetCommand, int>
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<int> Handle(RemoveScenarioFromTrialSetCommand message)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{message.ServerUrl}/api/TrialSet/{message.TrialSetId}/scenario/{message.ScenarioId}");
                string content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);

                return 0;
            }
        }
    }
}