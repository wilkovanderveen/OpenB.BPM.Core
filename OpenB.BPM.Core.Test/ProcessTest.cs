using Moq;
using NUnit.Framework;

namespace OpenB.BPM.Core.Test
{

    [TestFixture]
    public class ProcessTest
    {
        [Test]
        public void Process_Start_InitialState_IsSet()
        {
            StateDefinition initialState = new StateDefinition();
            ProcessDefinition processDefinition = new ProcessDefinition("Demo", "Demo process", initialState);
            ProcessContext processContext = new ProcessContext(new ModelCollection());

            Process process = new Process(processDefinition, processContext);
            process.Start();

            Assert.That(process.CurrentState.StateDefinition, Is.EqualTo(initialState));
        }

        [Test]
        public void Process_Transistions_AreRun()
        {
            StateDefinition initialState = new StateDefinition();
            StateDefinition nextState = new StateDefinition();
            ProcessContext processContext = new ProcessContext(new ModelCollection());

            StateTransistion firstTransistion = new StateTransistion(1, "Demo for moving to next state", nextState);

            initialState.Transistions.Add(firstTransistion);

            ProcessDefinition processDefinition = new ProcessDefinition("Demo", "Demo process", initialState);

            Process process = new Process(processDefinition, processContext);
            process.Start();

            Assert.That(process.CurrentState.StateDefinition, Is.EqualTo(nextState));
        }

        [Test]
        public void Process_Transistions_AreRunWithEvents()
        {
            StateDefinition initialState = new StateDefinition();
            StateDefinition nextState = new StateDefinition();
            ProcessContext processContext = new ProcessContext(new ModelCollection());

            Mock<IBusinessEvent> businessEventMock = new Mock<IBusinessEvent>();
            businessEventMock.Setup(b => b.Execute()).Verifiable();            

            nextState.Events.Add(businessEventMock.Object);           

            StateTransistion firstTransistion = new StateTransistion(1, "Demo for moving to next state" ,nextState);

            initialState.Transistions.Add(firstTransistion);

            ProcessDefinition processDefinition = new ProcessDefinition("Demo", "Demo process", initialState);

            Process process = new Process(processDefinition, processContext);
            process.Start();

            businessEventMock.VerifyAll();

            Assert.That(process.CurrentState.StateDefinition, Is.EqualTo(nextState));
          

        }

    }
}
