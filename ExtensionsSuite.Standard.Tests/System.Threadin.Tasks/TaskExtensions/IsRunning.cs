using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.Threadin.Tasks.TaskExtensions
{
    [TestClass]
    public class IsRunning
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TaskSourceNullTest()
        {
            Task task = null;
            task.IsRunning();
        }

        [TestMethod]
        public void NoneStartedTaskTest()
        {
            object testObject = new object();
            Task task = new Task(() => testObject = null);

            Assert.IsFalse(task.IsRunning());
        }

        [TestMethod]
        public void WaitingTaskTest()
        {
            bool wait = true;
            object testObject = new object();
            Task task = Task.Run(
                () =>
                {
                    while (wait) { }
                });

            Assert.IsTrue(task.IsRunning());
            wait = false;
            task.Wait();
            Assert.IsFalse(task.IsRunning());

        }
    }
}
