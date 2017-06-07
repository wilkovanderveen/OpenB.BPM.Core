using System.Collections.Generic;
using System.Linq;

namespace OpenB.BPM.Core.Test
{
    public class ModelDefinition
    {
        internal IList<PropertyDefinition> propertyDefinitions;

        public ModelDefinition(string name)
        {
            propertyDefinitions = new List<PropertyDefinition>();
            DefinedTypeName = name;
        }

        public string DefinedTypeName { get; internal set; }

        internal void AddProperty(string propertyName, ModelDefinition modelDefinition)
        {
            propertyDefinitions.Add(new PropertyDefinition(modelDefinition, propertyName));
        }

        internal PropertyDefinition GetPropertyDefinition(string propertyName)
        {
            return propertyDefinitions.Single(p => p.Name.Equals(propertyName));
        }
    }
}
