using System.Collections.Generic;

namespace OpenB.BPM.Core
{
    public class StateDefinition
    {
        public IList<StateTransistion> Transistions { get; private set; }
        public IList<IBusinessEvent> Events { get; private set; }

        public StateDefinition()
        {
            Transistions = new List<StateTransistion>();
            Events = new List<IBusinessEvent>();
        }
    }
}
