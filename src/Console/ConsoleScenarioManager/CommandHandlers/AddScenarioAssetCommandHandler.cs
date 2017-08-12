using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConsoleScenarioManager.Commands;
using MediatR;
using Newtonsoft.Json;

namespace ConsoleScenarioManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="int" />
    public class AddScenarioAssetCommandHandler : IAsyncRequestHandler<AddScenarioAssetCommand, int>
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task<int> Handle(AddScenarioAssetCommand command)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(new
                {
                    command.Tag,
                    Position = VectorDto.GetVector(command.Position),
                    Rotation = VectorDto.GetVector(command.Rotation),
                    Scale = VectorDto.GetVector(command.Scale)
                });
                HttpResponseMessage response = await client.PostAsync($"{command.ServerUrl}/api/procedure/{command.ProcedureId}/scenario/{command.ScenarioId}/asset",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                string content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);

                return 0;
            }
        }
    }
}