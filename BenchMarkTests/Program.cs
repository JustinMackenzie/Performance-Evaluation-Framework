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

            testRunner.RunScenarioSimulatorTests(1000);
            testRunner.RunParameterTrackingTests(1000);
            testRunner.RunCsvLoggingComponentTests(1000);
            testRunner.RunTextLoggingTests(1000);
            testRunner.RunTimeKeepingTests(1000);
            testRunner.RunEventCollectionTests(1000);
            testRunner.RunStateChartTest(1000);

            Console.ReadLine();
        }
    }
}
