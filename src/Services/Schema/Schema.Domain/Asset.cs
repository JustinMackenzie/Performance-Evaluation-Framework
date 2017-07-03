using Schema.Domain.SeedWork;

namespace Schema.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Schema.Domain.SeedWork.Entity" />
    public class Asset : Entity
    {
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// The tag
        /// </summary>
        private string _tag;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => this._name;

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag => this._tag;

        /// <summary>
        /// Initializes a new instance of the <see cref="Asset" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="tag">The tag.</param>
        public Asset(string name, string tag)
        {
            this._name = name;
            this._tag = tag;
        }

    }
}
