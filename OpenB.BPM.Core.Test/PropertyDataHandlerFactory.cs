namespace OpenB.BPM.Core.Test
{
    internal class PropertyDataHandlerFactory
    {
        internal static IDataHandler GetHandler(PropertyDefinition propertyDefinition)
        {
            return new DefaultPropertyDataHandler(propertyDefinition);
        }
    }
}
