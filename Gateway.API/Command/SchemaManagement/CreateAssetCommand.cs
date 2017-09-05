using System;
using MediatR;
using SchemaManagement.Domain;

namespace Gateway.API.Command.SchemaManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest{SchemaManagement.Domain.Asset}" />
    public class CreateAssetCommand : IRequest<Asset>
    {
        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>
        /// The schema identifier.
        /// </value>
        public Guid SchemaId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; set; }
    }
}
