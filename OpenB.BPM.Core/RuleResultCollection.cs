using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenB.BPM.Core
{
    public class RuleResultCollection
    {
        private StateTransistion stateTransistion;
        public IList<RuleResult> RuleResults { get; private set; }
        public bool Success
        {
            get { return RuleResults.All(r => r.Success); }
        }

        public RuleResultCollection(StateTransistion stateTransistion)
        {
            if (stateTransistion == null)
                throw new NullReferenceException(nameof(stateTransistion));

            RuleResults = new List<RuleResult>();
            this.stateTransistion = stateTransistion;
        }

        internal void AddResult(RuleResult result)
        {
            RuleResults.Add(result);
        }
    }
}
