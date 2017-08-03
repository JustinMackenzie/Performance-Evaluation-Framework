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
    /// <seealso cref="MediatR.IAsyncRequestHandler{ConsoleTrialSetManager.Commands.UpdateTrialSetNameCommand, System.Int32}" />
    public class UpdateTrialSetNameCommandHandler : IAsyncRequestHandler<UpdateTrialSetNameCommand, int>
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<int> Handle(UpdateTrialSetNameCommand message)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(new
                {
                    message.Name
                });

                HttpResponseMessage response = await client.PutAsync($"{message.ServerUrl}/api/TrialSet/{message.TrialSetId}/name",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                string content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);

                return 0;
            }
        }
    }
}
