using OpenB.Core;
using System.Collections.Generic;
using System.Linq;

namespace OpenB.BPM.Core.Test
{
    internal class ModelDefinitionConfiguration : IConfiguration
    {
        private IList<ModelDefinition> modelDefinitions;

        internal static ModelDefinitionConfiguration instance;

        public static ModelDefinitionConfiguration GetInstance()
        {
            if (instance == null)
            {
                // TODO: Implement configuration reader.
                instance = new ModelDefinitionConfiguration(new List<ModelDefinition>());
            }

            return instance;
        }

        internal ModelDefinitionConfiguration(IList<ModelDefinition> definitions)
        {
            modelDefinitions = definitions;
        }

        public ModelDefinition GetDefinitionByType<T>() where T : IModel
        {
            var foundDefinitions = modelDefinitions.Where(d => d.DefinedTypeName == typeof(T).Name);

            if (!foundDefinitions.Any())
            {
                throw new InvalidConfigurationException();
            }

            return foundDefinitions.First();

        }
    }
}
