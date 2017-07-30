using System;
using System.Threading.Tasks;
using SchemaManagement.Domain.SeedWork;

namespace SchemaManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Schema" />
    public interface ISchemaRepository : IRepository<Schema>
    {
        /// <summary>
        /// Adds the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        System.Threading.Tasks.Task Add(Schema schema);

        /// <summary>
        /// Updates the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        System.Threading.Tasks.Task Update(Schema schema);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Schema> Get(Guid id);
    }
}
