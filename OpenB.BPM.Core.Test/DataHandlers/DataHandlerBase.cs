namespace OpenB.BPM.Core.Test
{
    public abstract class DataHandlerBase
    {
        protected PropertyDefinition PropertyDefinition { get; private set; }

        public DataHandlerBase(PropertyDefinition propertyDefinition)
        {
            
        }

        public abstract void Handle(object parentObject);
    }

}