using System;
using Ninject;
using ScenarioSim.Infrastructure.DependencyResolution;

namespace BenchMarkTests
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(new SimulatorModule(new MockEntityPlacer()));
            kernel.Load(new SerializationModule());
            kernel.Load(new PlaybackModule());

            TestRunner testRunner = new TestRunner(kernel);

            //testRunner.RunScenarioSimulatorTests(100000);
            //testRunner.RunParameterTrackingTests(100000);
            //testRunner.RunCsvLoggingComponentTests(100000);
            //testRunner.RunTextLoggingTests(100000);
            //testRunner.RunTimeKeepingTests(100000);
            //testRunner.RunEventCollectionTests(100000);
            testRunner.RunStateChartTest(100000);

            Console.ReadLine();
        }
    }
}
