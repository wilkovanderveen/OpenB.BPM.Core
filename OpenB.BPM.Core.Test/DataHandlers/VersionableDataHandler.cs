using System;

namespace OpenB.BPM.Core.Test
{
    public class VersionableDataHandler : DataHandlerBase, IDataHandler
    {
        public VersionableDataHandler(PropertyDefinition propertyDefinition) : base(propertyDefinition)
        { }

        public string Name { get { return "Versionable"; } }

        public string Description { get { return "Versionable."; } }

        public override void Handle(object property)
        {
            throw new NotImplementedException();
        }
    }

}