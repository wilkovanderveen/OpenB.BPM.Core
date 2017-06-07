namespace OpenB.BPM.Core.Test
{
    public interface IDataHandler
    {
        void Handle(object property);
        string Name { get; }
        string Description { get; }
    }

}