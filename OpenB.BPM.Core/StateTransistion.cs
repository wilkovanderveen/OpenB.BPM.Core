using System.Collections.Generic;

namespace OpenB.BPM.Core
{
    public class StateTransistion
    {

        public IList<IBusinessRule> BusinessRules { get; private set; }
        public StateDefinition NextResult { get; private set; }
        public int Index { get; private set; }
        public string Description { get; private set; }

        public StateTransistion(int index, string description, StateDefinition nextDefinition)
        {
            Index = index;
            Description = description;

            BusinessRules = new List<IBusinessRule>();
            NextResult = nextDefinition;
        }

        public RuleResultCollection EvaluateBusinessRules()
        {
            RuleResultCollection ruleResults = new RuleResultCollection(this);

            foreach (IBusinessRule businessRule in BusinessRules)
            {
                RuleResult result = businessRule.Evaluate();

                ruleResults.AddResult(result);
            }

            return ruleResults;
        }
    }
}
