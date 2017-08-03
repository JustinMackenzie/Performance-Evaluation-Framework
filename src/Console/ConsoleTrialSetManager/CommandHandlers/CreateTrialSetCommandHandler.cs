using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConsoleTrialSetManager.Commands;
using MediatR;
using Newtonsoft.Json;

namespace ConsoleTrialSetManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{CreateTrialSetCommand, int}" />
    public class CreateTrialSetCommandHandler : IAsyncRequestHandler<CreateTrialSetCommand, int>
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task<int> Handle(CreateTrialSetCommand command)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(new
                {
                    command.Name
                });

                HttpResponseMessage response = await client.PostAsync($"{command.ServerUrl}/api/TrialSet",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                string content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);

                return 0;
            }
        }
    }
}