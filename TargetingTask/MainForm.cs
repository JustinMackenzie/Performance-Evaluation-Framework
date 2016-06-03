using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScenarioSim.Core.Entities;
using ScenarioSim.Infrastructure.SimulationComponents;
using ScenarioSim.Infrastructure.Simulator;
using ScenarioSim.Infrastructure.UmlStateChart;
using ScenarioSim.Infrastructure.XmlSerialization;
using ScenarioSim.Services.Simulator;

namespace TargetingTask
{
    public partial class MainForm : Form, IEntityPlacer
    {
        private List<Scenario> scenarios;
        private int currentScenario;
        IComplicationEnactorRepository enactorRepository = new ComplicationEnactorRepository();
        ISimulationComponentRepository componentRepository = new SimulationComponentRepository();
        private Button firstTarget;
        private Button target;
        private IScenarioSimulator simulator;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            string filename = dialog.FileName;

            XmlFileSerializer<List<Scenario>> serializer = new XmlFileSerializer<List<Scenario>>();

            scenarios = serializer.Deserialize(filename);
             */

            scenarios = new List<Scenario>();

            Scenario scenario = GenerateScenario();

            scenarios.Add(scenario);

            StartScenario(scenarios.First());
        }

        private Scenario GenerateScenario()
        {
            Scenario result = new Scenario();

            result.Name = "Targeting Task 1";
            result.Entities.Add(new Entity
            {
                Id = 1,
                Name = "First Button",
                transform = new Transform
                {
                    Position = new Vector3f(20, 20, 0),
                    Rotation = new Vector3f(),
                    Scale = new Vector3f(20, 20, 1)
                }
            });
            result.Entities.Add(new Entity
            {
                Id = 2,
                Name = "Second Button",
                transform = new Transform
                {
                    Position = new Vector3f(60, 60, 0),
                    Rotation = new Vector3f(),
                    Scale = new Vector3f(20, 20, 1)
                }
            });

            Task task = new Task
            {
                EvaluateValue = false,
                Name = "Targeting Task"

            };

            result.Task = new TreeNode<Task>(task);
            result.Task.AppendChild(new Task { Name = "Select Target 1" });
            result.Task.AppendChild(new Task
            {
                Name = "Select Target 2"
            });
            result.Task.AppendChild(new Task { Name = "Evaluate", Final = true });

            result.TaskTransitions.Add(new TaskTransition
            {
                Source = "Select Target 1",
                Destination = "Select Target 2",
                EventId = 1
            });
            result.TaskTransitions.Add(new TaskTransition
            {
                Source = "Select Target 2",
                Destination = "Evaluate",
                EventId = 2
            });

            return result;
        }

        private void StartScenario(Scenario scenario)
        {
            enactorRepository = new ComplicationEnactorRepository();
            componentRepository = new SimulationComponentRepository();

            AddComponents(componentRepository);

            simulator = new ScenarioSimulator(this, enactorRepository, componentRepository);
            simulator.Start(scenario);
        }

        private void AddComponents(ISimulationComponentRepository simulationComponentRepository)
        {
            StateChartComponent stateChart = new StateChartComponent(new UmlStateChartBuilder());
            simulationComponentRepository.AddComponent(stateChart);

            simulationComponentRepository.AddComponent(new TimeKeeperComponent(stateChart));
            simulationComponentRepository.AddComponent(new ScenarioEventCollectionComponent("Events.xml", new XmlFileSerializer<List<ScenarioEvent>>()));
        }

        public void Place(Entity entity)
        {
            Button button = new Button
                {
                    Location = new Point((int)entity.transform.Position.X,
                        (int)entity.transform.Position.Y),
                    Size = new Size((int)entity.transform.Scale.X,
                        (int)entity.transform.Scale.Y),
                    Tag = entity.Id,
                    BackColor = Color.Red
                };

            firstTarget.MouseDown += ButtonOnMouseDown;
            firstTarget.MouseUp += ButtonOnMouseUp;

            if (entity.Id == 1)
            {
                firstTarget = button;
                Controls.Add(firstTarget);
            }
            else
            {
                target = button;
            }
        }

        private void ButtonOnMouseDown(object sender, MouseEventArgs mouseEventArgs)
        {
            simulator.SubmitSimulatorEvent(new DownClickEvent(mouseEventArgs.X, mouseEventArgs.Y));
        }

        private void ButtonOnMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            Button button = (Button)sender;

            simulator.SubmitSimulatorEvent(new UpClickEvent(mouseEventArgs.X, mouseEventArgs.Y));

            if ((int)button.Tag == 1)
            {
                Controls.Add(target);
                Controls.Remove(firstTarget);
            }
            else
            {
                ResultsForm resultsForm = new ResultsForm();
                resultsForm.ShowDialog();

                LoadNextScenario();
            }
        }

        public void LoadNextScenario()
        {
            currentScenario++;

            if (currentScenario < scenarios.Count)
                StartScenario(scenarios[currentScenario]);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            simulator.SubmitSimulatorEvent(new MoveMouseEvent(e.X, e.Y));
        }
    }
}
