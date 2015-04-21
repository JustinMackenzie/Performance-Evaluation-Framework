using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ninject;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Infrastructure.SimulationComponents;
using ScenarioSim.Services.Simulator;

namespace BenchMarkTests
{
    class TestRunner
    {
        private Scenario scenario;
        private IKernel kernel;

        public TestRunner(IKernel kernel)
        {
            scenario = kernel.Get<IFileSerializer<Scenario>>().Deserialize("Longest Axis 1.scenario");

            this.kernel = kernel;
        }

        private void RunTest(ScenarioEvent e, IEnumerable<ITest> tests, string type)
        {
            List<float> results = new List<float>();

            foreach (ITest test in tests)
            {
                test.Execute(e);
                results.Add(test.Result);
            }

            float mean = results.Sum() / results.Count;
            float variance = 0;

            foreach (float result in results)
                variance += (result - mean) * (result - mean);

            variance = variance / results.Count;
            float standardDev = (float)Math.Sqrt(variance);

            Console.WriteLine("Results for {0} {1} tests:", tests.Count(), type);
            Console.WriteLine("The mean time per event: {0} milliseconds.", mean);
            Console.WriteLine("The maximum time taken was: {0} milliseconds", results.Max());
            Console.WriteLine("The minimum time taken was: {0} milliseconds", results.Min());
            Console.WriteLine("The variance was: {0}", variance);
            Console.WriteLine("The standard deviation was: {0}", standardDev);

            /*using (StreamWriter writer = new StreamWriter(string.Format("{0}.csv", type)))
            {
                foreach (float result in results)
                {
                    writer.WriteLine(result);
                }
            }*/
        }

        public void RunScenarioSimulatorTests(int n)
        {
            List<ITest> tests = new List<ITest>();

            for (int i = 0; i < n; i++)
                tests.Add(new ScenarioSimulatorTest(scenario, kernel.Get<IScenarioSimulator>()));

            ScenarioEvent e = new ScenarioEvent()
            {
                Id = 3,
                Description = "A test event.",
                Name = "test",
                Timestamp = DateTime.Now,
                Parameters = new EventParameterCollection()
            };

            RunTest(e, tests, "scenario simulator");
        }

        public void RunParameterTrackingTests(int n)
        {
            List<ITest> tests = new List<ITest>();

            for (int i = 0; i < n; i++)
            {
                tests.Add(new ComponentTest(new ParameterTrackingComponent(), scenario));
            }

            ScenarioEvent e = new ScenarioEvent()
            {
                Id = 3,
                Description = "A test event.",
                Name = "test",
                Timestamp = DateTime.Now,
                Parameters = new EventParameterCollection()
            };

            RunTest(e, tests, "parameter tracking");
        }

        public void RunCsvLoggingComponentTests(int n)
        {
            List<ITest> tests = new List<ITest>();

            for (int i = 0; i < n; i++)
            {
                tests.Add(new ComponentTest(new CsvLoggingComponent("test.csv"), scenario));
            }

            ScenarioEvent e = new ScenarioEvent()
            {
                Id = 3,
                Description = "A test event.",
                Name = "test",
                Timestamp = DateTime.Now,
                Parameters = new EventParameterCollection()
            };

            RunTest(e, tests, "csv logging");
        }

        public void RunTextLoggingTests(int n)
        {
            List<ITest> tests = new List<ITest>();

            for (int i = 0; i < n; i++)
            {
                tests.Add(new ComponentTest(new TextLoggingComponent("test.txt"), scenario));
            }

            ScenarioEvent e = new ScenarioEvent()
            {
                Id = 3,
                Description = "A test event.",
                Name = "test",
                Timestamp = DateTime.Now,
                Parameters = new EventParameterCollection()
            };

            RunTest(e, tests, "text logging");
        }

        public void RunTimeKeepingTests(int n)
        {
            List<ITest> tests = new List<ITest>();

            for (int i = 0; i < n; i++)
            {
                IScenarioSimulator simulator = kernel.Get<IScenarioSimulator>();
                simulator.Start(scenario);
                StateChartComponent stateChart = new StateChartComponent(kernel.Get<IStateChartBuilder>());
                tests.Add(new ComponentTest(new TimeKeeperComponent(stateChart), scenario));
            }

            ScenarioEvent e = new ScenarioEvent()
            {
                Id = 3,
                Description = "A test event.",
                Name = "test",
                Timestamp = DateTime.Now,
                Parameters = new EventParameterCollection()
            };

            RunTest(e, tests, "time keeper");
        }

        public void RunEventCollectionTests(int n)
        {
            List<ITest> tests = new List<ITest>();

            for (int i = 0; i < n; i++)
                tests.Add(new ComponentTest(new ScenarioEventCollectionComponent("events.xml", kernel.Get<IFileSerializer<List<ScenarioEvent>>>()), scenario));

            ScenarioEvent e = new ScenarioEvent()
            {
                Id = 3,
                Description = "A test event.",
                Name = "test",
                Timestamp = DateTime.Now,
                Parameters = new EventParameterCollection()
            };

            RunTest(e, tests, "event collection");
        }
    }
}
