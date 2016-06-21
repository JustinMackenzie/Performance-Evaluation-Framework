using System;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.ScenarioCreator;

namespace ScenarioSim.Infrastructure.ScenarioCreator
{
    public class SchemaManager : ISchemaManager
    {
        private readonly ILogger logger;
        private readonly IUnitOfWork unitOfWork;

        public SchemaManager(ILogger logger, IUnitOfWork unitOfWork)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public Schema GetSchema(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            try
            {
                return unitOfWork.SchemaRepository.Get(id);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        public void CreateSchema(Schema schema)
        {
            if (schema == null)
                throw new ArgumentNullException(nameof(schema));

            try
            {
                schema.Id = Guid.NewGuid();
                unitOfWork.SchemaRepository.Save(schema);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }
    }
}
