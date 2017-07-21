using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleSchemaManager.Commands;
using ConsoleSchemaManager.Services;

namespace ConsoleSchemaManager.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.CommandHandlers.ICommandHandler{ConsoleSchemaManager.Commands.SetScenarioAssetCommand}" />
    public class SetScenarioAssetCommandHandler : ICommandHandler<SetScenarioAssetCommand>
    {
        /// <summary>
        /// The schema service
        /// </summary>
        private readonly ISchemaService _schemaService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetScenarioAssetCommandHandler"/> class.
        /// </summary>
        /// <param name="schemaService">The schema service.</param>
        public SetScenarioAssetCommandHandler(ISchemaService schemaService)
        {
            this._schemaService = schemaService;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public int Handle(SetScenarioAssetCommand command)
        {
            try
            {
                SetScenarioAssetRequest request = new SetScenarioAssetRequest
                {
                    ServerUrl = command.ServerUrl,
                    AssetId = Guid.Parse(command.AssetId),
                    ScenarioId = Guid.Parse(command.ScenarioId),
                    SchemaId = Guid.Parse(command.SchemaId),
                    Position = this.GetVector(command.Position),
                    Rotation = this.GetVector(command.Rotation),
                    Scale = this.GetVector(command.Scale)
                };

                this._schemaService.SetScenarioAsset(request);
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }
        }

        /// <summary>
        /// Gets the vector.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        private VectorDto GetVector(IEnumerable<string> input)
        {
            List<string> inputList = input.ToList();

            return new VectorDto
            {
                X = float.Parse(inputList[0]),
                Y = float.Parse(inputList[1]),
                Z = float.Parse(inputList[2])
            };
        }
    }
}
