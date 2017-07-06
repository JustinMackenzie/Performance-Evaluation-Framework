using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSchemaManager.Services
{
    public interface ISchemaService
    {
        void CreateSchema(CreateSchemaRequest request);
        void CreateScenario(CreateScenarioRequest request);
    }
}
