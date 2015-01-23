using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ScenarioSim.Core;
using System.IO;
using NSubstitute;

namespace ScenarioSim.Core.Test
{
    [TestFixture]
    class SimulatorCommandRecieverTests
    {
        [Test]
        public void TestCreateWriteLog()
        {
            int Id = 0;
            string Name = "Test Command";
            string Description = "A description.";
            DateTime timestamp = DateTime.Now;
            Dictionary<string, object> parameters = new Dictionary<string,object>();
            parameters.Add("A parameter", 5);

            IStateChart stateChart = Substitute.For<IStateChart>();


            StateChartEventHandler rec = new StateChartEventHandler(stateChart);

            SimulatorEventHandler reciever = new SimulatorEventHandler(rec);

            for(int i = 0; i < 500; i++)
            {
                reciever.SubmitEvent(new SimulatorEvent() { Id = Id, Name = Name, Description = Description, Timestamp = timestamp, Parameters = parameters });
            }
            
            string filename = "simEvents.log";
            string filename2 = "stateEvents.log";
            reciever.WriteToLog(filename);
            rec.Write(filename2);

            Assert.IsTrue(File.Exists(filename));
        }
    }
}
