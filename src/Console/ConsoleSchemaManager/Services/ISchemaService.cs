using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSchemaManager.CommandHandlers;

namespace ConsoleSchemaManager.Services
{
    public interface ISchemaService
    {
        void CreateSchema(CreateSchemaRequest request);
        void CreateScenario(CreateScenarioRequest request);
        void CreateSchemaEvent(CreateSchemaEventRequest request);
        void CreateSchemaTask(CreateSchemaTaskRequest request);
    }
}
