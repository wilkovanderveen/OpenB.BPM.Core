namespace OpenB.BPM.Core
{
    public class RuleResult
    {
        public bool Success { get; private set; }

        public RuleResult(bool success)
        {
            Success = success;
        }
    }
}
