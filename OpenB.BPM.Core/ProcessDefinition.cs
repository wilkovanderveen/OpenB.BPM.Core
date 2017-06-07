using System;

namespace OpenB.BPM.Core
{
    public class ProcessDefinition
    {
        public StateDefinition StartingState { get; private set; }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public ProcessDefinition(string name, string description, StateDefinition startingDefinition)
        {
            if (startingDefinition == null)
                throw new ArgumentNullException(nameof(startingDefinition));

            StartingState = startingDefinition;
            Name = name;
            Description = description;
        }

    }
}
