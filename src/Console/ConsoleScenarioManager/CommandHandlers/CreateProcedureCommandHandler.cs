using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;

namespace ConsoleScenarioManager.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{ConsoleScenarioManager.Commands.CreateProcedureCommand, System.Int32}" />
    public class CreateProcedureCommandHandler : IAsyncRequestHandler<CreateProcedureCommand, int>
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<int> Handle(CreateProcedureCommand message)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(new { message.Name });
                HttpResponseMessage response = await client.PostAsync($"{message.ServerUrl}/api/procedure",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                string content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);

                return 0;
            }
        }
    }
}