namespace ConsoleSchemaManager.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISchemaService
    {
        /// <summary>
        /// Creates the schema.
        /// </summary>
        /// <param name="request">The request.</param>
        void CreateSchema(CreateSchemaRequest request);

        /// <summary>
        /// Creates the scenario.
        /// </summary>
        /// <param name="request">The request.</param>
        void CreateScenario(CreateScenarioRequest request);

        /// <summary>
        /// Creates the schema event.
        /// </summary>
        /// <param name="request">The request.</param>
        void CreateSchemaEvent(CreateSchemaEventRequest request);

        /// <summary>
        /// Creates the schema task.
        /// </summary>
        /// <param name="request">The request.</param>
        void CreateSchemaTask(CreateSchemaTaskRequest request);

        /// <summary>
        /// Creates the task transition.
        /// </summary>
        /// <param name="request">The request.</param>
        void CreateTaskTransition(CreateTaskTransitionRequest request);

        void CreateSchemaAsset(CreateSchemaAssetRequest request);

        void SetScenarioAsset(SetScenarioAssetRequest request);
    }
}
