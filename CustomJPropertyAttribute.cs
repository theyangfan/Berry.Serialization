using System;
using System.Collections.Generic;
using System.Text;

namespace Berry.Serialization
{
    /// <summary>
    /// Instructs the serialize name and ability.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class CustomJPropertyAttribute : Attribute
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the Berry.Serialization.CustomJPropertyAttribute class.
        /// </summary>
        public CustomJPropertyAttribute()
        {
            Serializable = true;
            Deserializable = true;
        }

        /// <summary>
        /// Initializes a new instance of the Berry.Serialization.CustomJPropertyAttribute class
        /// with the specified name.
        /// </summary>
        /// <param name="propertyName"></param>
        public CustomJPropertyAttribute(string propertyName)
        {
            Serializable = true;
            Deserializable = true;
            Name = propertyName;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets a value indicating whether serialize the property.
        /// The default value is true.
        /// </summary>
        public bool Serializable { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether deserialize the property .
        /// The default value is true.
        /// </summary>
        public bool Deserializable { get; set; } = true;

        /// <summary>
        /// Gets or sets the name of the property when serializing.
        /// </summary>
        public string SerializeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the property when deserializing.
        /// </summary>
        public string DeserializeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the property when serializing or deserializing.
        /// The priority is lower than <see cref="SerializeName"/> and <see cref="DeserializeName"/>.
        /// </summary>
        public string Name { get; set; }
        #endregion
    }
}
