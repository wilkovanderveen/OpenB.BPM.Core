using System;

namespace OpenB.BPM.Core.Test
{
    public class AuthorizableDataHandler : DataHandlerBase, IDataHandler
    {
        public AuthorizableDataHandler(PropertyDefinition propertyDefinition) : base(propertyDefinition)
        { }

        public string Name { get { return "Authorizable"; } }

        public string Description { get { return "Authorizable."; } }

        public override void Handle(object property)
        {
            throw new NotImplementedException();
        }
    }

}