using SchemaManagement.Domain.SeedWork;

namespace SchemaManagement.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SchemaManagement.Domain.SeedWork.Entity" />
    /// <seealso cref="Schema.Domain.SeedWork.Entity" />
    public class Asset : Entity
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Asset" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="tag">The tag.</param>
        public Asset(string name, string tag)
        {
            this.Name = name;
            this.Tag = tag;
        }
    }
}
