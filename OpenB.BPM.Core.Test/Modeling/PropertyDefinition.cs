namespace OpenB.BPM.Core.Test
{
    public class PropertyDefinition
    {
        public string Name { get; private set; }
        public ModelDefinition ModelDefinition { get; private set; }

        public PropertyDefinition(ModelDefinition modelDefinition, string name)
        {
            ModelDefinition = modelDefinition;
            Name = name;
        }
    }
}
