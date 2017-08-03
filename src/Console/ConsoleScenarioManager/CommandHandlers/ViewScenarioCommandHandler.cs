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
    /// <seealso cref="MediatR.IAsyncRequestHandler{ConsoleScenarioManager.Commands.ViewScenarioCommand, System.Int32}" />
    public class ViewScenarioCommandHandler : IAsyncRequestHandler<ViewScenarioCommand, int>
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<int> Handle(ViewScenarioCommand message)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response =
                    await client.GetAsync($"{message.ServerUrl}/api/Scenario/{message.ScenarioId}");
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                return 0;
            }
        }
    }
}