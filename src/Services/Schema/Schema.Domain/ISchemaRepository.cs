using System;
using Schema.Domain.SeedWork;

namespace Schema.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Schema.Domain.IRepository{Schema.Domain.Schema}" />
    public interface ISchemaRepository : IRepository<Schema>
    {
        /// <summary>
        /// Adds the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        void Add(Schema schema);

        /// <summary>
        /// Updates the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        void Update(Schema schema);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Schema Get(Guid id);
    }
}
