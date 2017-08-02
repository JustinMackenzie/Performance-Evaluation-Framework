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
        ApiResponse CreateSchema(CreateSchemaRequest request);

        /// <summary>
        /// Creates the schema event.
        /// </summary>
        /// <param name="request">The request.</param>
        ApiResponse CreateSchemaEvent(CreateSchemaEventRequest request);

        /// <summary>
        /// Creates the schema task.
        /// </summary>
        /// <param name="request">The request.</param>
        ApiResponse CreateSchemaTask(CreateSchemaTaskRequest request);

        /// <summary>
        /// Creates the task transition.
        /// </summary>
        /// <param name="request">The request.</param>
        ApiResponse CreateTaskTransition(CreateTaskTransitionRequest request);

        /// <summary>
        /// Creates the schema asset.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        ApiResponse CreateSchemaAsset(CreateSchemaAssetRequest request);
    }
}
