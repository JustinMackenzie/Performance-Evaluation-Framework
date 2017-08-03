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
    /// <seealso cref="MediatR.IAsyncRequestHandler{ConsoleScenarioManager.Commands.ViewAllScenariosCommand, System.Int32}" />
    public class ViewAllScenariosCommandHandler : IAsyncRequestHandler<ViewAllScenariosCommand, int>
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<int> Handle(ViewAllScenariosCommand message)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{message.ServerUrl}/api/Scenario");
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                return 0;
            }
        }
    }
}