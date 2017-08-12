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
    /// <seealso cref="MediatR.IAsyncRequestHandler{ConsoleScenarioManager.Commands.RemoveProcedureCommand, System.Int32}" />
    public class RemoveProcedureCommandHandler : IAsyncRequestHandler<RemoveProcedureCommand, int>
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<int> Handle(RemoveProcedureCommand message)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{message.ServerUrl}/api/procedure/{message.ProcedureId}");
                string content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);

                return 0;
            }
        }
    }
}