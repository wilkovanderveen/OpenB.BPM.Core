namespace OpenB.BPM.Core
{
    /// <summary>
    /// Business rules must implement this interface for being processed.
    /// </summary>
    public interface IBusinessRule
    {
        /// <summary>
        /// Evaluates a business rule.
        /// <returns>Rule result.</returns>
        RuleResult Evaluate();      
    }
}
