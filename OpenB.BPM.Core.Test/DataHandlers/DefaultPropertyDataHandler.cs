using System;

namespace OpenB.BPM.Core.Test
{
    internal class DefaultPropertyDataHandler : DataHandlerBase, IDataHandler
    {
        public DefaultPropertyDataHandler(PropertyDefinition propertyDefinition) : base(propertyDefinition)
        { }

        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public override void Handle(object property)
        {
           
        }
    }

}