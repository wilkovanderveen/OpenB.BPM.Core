namespace OpenB.BPM.Core
{
    public interface IBusinessEvent
    {
        void Execute();
        void RollBack();
       
    }
}
