namespace OpenB.BPM.Core
{
    public class TransistionResult
    {
        public bool Success { get; private set; }
        public StateDefinition ResultingState { get; private set; }

        public TransistionResult(bool success, StateDefinition resultingState)
        {
            this.Success = success;
            this.ResultingState = resultingState;
        }

        public TransistionResult(bool success)
        {
            this.Success = success;
        }
    }
}
