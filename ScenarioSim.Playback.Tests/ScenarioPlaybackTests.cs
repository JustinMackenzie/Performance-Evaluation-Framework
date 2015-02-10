using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.Playback;
using ScenarioSim.Core;
using NUnit.Framework;
using NSubstitute;

namespace ScenarioSim.Playback.Tests
{
    [TestFixture]
    class ScenarioPlaybackTests
    {
        [Test]
        public void TestCallEnactorNTimes()
        {
            ScenarioEventCollection collection = new ScenarioEventCollection();

            Random r = new Random();

            int n = r.Next(100);

            for(int i = 0; i < n; i++)
            {
                ScenarioEvent expectedEvent = new ScenarioEvent()
                {
                    Id = 1,
                    Timestamp = DateTime.Now.AddMilliseconds(-150 + i )
                };
                collection.Add(expectedEvent);
            }

            IScenarioPlayback pb = new ScenarioPlayback(collection);
            IEventEnactor enactor = Substitute.For<IEventEnactor>();
            enactor.EventId.Returns(1);
            pb.EnqueueEnactor(enactor);

            pb.Play();

            System.Threading.Thread.Sleep(150);
            foreach (ScenarioEvent e in collection)
                enactor.Received().Enact(e);
        }

        
        public void TestPause()
        {
            ScenarioEventCollection collection = new ScenarioEventCollection();

            Random r = new Random();
            int n = r.Next(200);
            int m = r.Next(n);

            for(int i = 0; i < n; i++)
            {
                ScenarioEvent e = new ScenarioEvent()
                {
                    Id = 1,
                    Timestamp = DateTime.Now.AddMilliseconds(-200 + i)
                };

                if (i == m)
                    e.Id = 2;

                collection.Add(e);
            }

            IScenarioPlayback pb = new ScenarioPlayback(collection);

            IEventEnactor enactor = new TestCountEnactor();
            enactor.EventId = 1;
            IEventEnactor testEnactor = new TestPauseEnactor(pb);
            testEnactor.EventId = 2;

            pb.EnqueueEnactor(enactor);
            pb.EnqueueEnactor(testEnactor);

            pb.Play();

            System.Threading.Thread.Sleep(210);

            Assert.IsTrue((enactor as TestCountEnactor).Count == m - 1);
        }

        [Test]
        public void ReadFroSerializeData()
        {
            IScenarioPlayback pb = new ScenarioPlayback("C:\\Users\\Jmac\\Documents\\2015-02-09-2002\\SimulatorEvents.xml");
            pb.Play();
        }
    }
}
