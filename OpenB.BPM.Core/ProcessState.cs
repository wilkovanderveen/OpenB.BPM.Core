using System;
using System.Linq;

namespace OpenB.BPM.Core
{
    public class ProcessState
    {
        public StateDefinition StateDefinition { get; private set; }

        public ProcessState(StateDefinition stateDefinition)
        {
            StateDefinition = stateDefinition;

            if (stateDefinition == null)
                throw new ArgumentNullException(nameof(stateDefinition));
        }

        public TransistionResult ExecuteTransistion()
        {

            foreach (StateTransistion stateTransition in StateDefinition.Transistions.OrderBy(t => t.Index))
            {
                var result = stateTransition.EvaluateBusinessRules();

                if (result.Success)
                {
                    return new TransistionResult(true, stateTransition.NextResult);
                }
            }

            return new TransistionResult(false);
        }

        internal void RunEvents()
        {
            foreach (IBusinessEvent ev in StateDefinition.Events)
            {
                ev.Execute();
            }
        }
    }
}
