using System;

namespace OpenB.BPM.Core
{
    public class Process
    {
        public ProcessDefinition ProcessDefinition { get; private set; }
        public ProcessState CurrentState { get; private set; }
        public ProcessContext ProcessContext { get; private set; }

        public Process(ProcessDefinition procesDefinition, ProcessContext procesContext)
        {
            if (procesContext == null)
                throw new ArgumentNullException(nameof(procesContext));
            if (procesDefinition == null)
                throw new ArgumentNullException(nameof(procesDefinition));

            ProcessDefinition = procesDefinition;
            ProcessContext = procesContext;
        }

        public void Start()
        {
            CurrentState = new ProcessState(ProcessDefinition.StartingState);
            CurrentState.RunEvents();

            ExecuteTransistion();

        }

        public void ExecuteTransistion()
        {
            var transitionResult = CurrentState.ExecuteTransistion();

            if (transitionResult.Success)
            {
                CurrentState = new ProcessState(transitionResult.ResultingState);
                CurrentState.RunEvents();

                ExecuteTransistion();
            }
        }
    }
}
