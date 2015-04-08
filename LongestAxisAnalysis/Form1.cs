using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScenarioSim.Simulator;
using ScenarioSim.Core;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using ScenarioSim.Playback;
using System.Diagnostics;

namespace LongestAxisAnalysis
{
    public partial class Form1 : Form
    {
        List<Scenario> scenarios;
        List<SimulationResult> results;
        int currentResult = 0;
        int CurrentEvent { get { return playback.CurrentEventIndex < 0 ? 0 : playback.CurrentEventIndex; } }
        StripLine eventStripLine;
        IScenarioPlayback playback;
        IEventEnactor enactor;
        List<List<EventParameter>> parameters;

        string PlaybackExecutable { get { return "playback.exe"; } }

        delegate void DrawEvent();

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IFileSerializer<SimulationResult> serializer = new XmlFileSerializer<SimulationResult>();
                IFileSerializer<Scenario> s = new XmlFileSerializer<Scenario>();
                results = new List<SimulationResult>();
                scenarios = new List<Scenario>();
                DirectoryInfo info = new DirectoryInfo(dialog.SelectedPath);

                FileInfo[] files = info.GetFiles("*.result");

                foreach (FileInfo f in files)
                {
                    SimulationResult r = serializer.Deserialize(f.FullName);
                    Scenario scenario = s.Deserialize(r.ScenarioFile);
                    results.Add(r);
                    scenarios.Add(scenario);
                }

                FileInfo parametersFile = info.GetFiles("parameters.csv").First();

                parameters = new List<List<EventParameter>>();

                using (StreamReader reader = new StreamReader(parametersFile.FullName))
                {

                    int lineNo = 0;
                    string line = string.Empty;
                    List<string> paramNames = new List<string>();
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineNo == 0)
                        {
                            paramNames = line.Split(',').ToList();
                            paramNames.RemoveAt(0);
                            lineNo++;
                            continue;
                        }

                        List<EventParameter> param = new List<EventParameter>();

                        int paramCount = -1;

                        foreach (string st in line.Split(','))
                        {
                            if(paramCount >= 0)
                                param.Add(new EventParameter() { Name = paramNames[paramCount], Value = st });
                            paramCount++;
                        }

                        parameters.Add(param);
                        lineNo++;
                    }

                }

                listView2.Columns.Add("Name");
                listView2.Columns.Add("Value");
                ChartData(results[0]);
                PopulateList();
            }
        }

        private void PopulateList()
        {
            listView1.Items.Clear();


            for (int i = 0; i < results.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = scenarios[i].Name;
                item.Tag = results[i];
                listView1.Items.Add(item);
            }
        }

        private void ChartData(SimulationResult result)
        {
            TaskResult taskResult = result.TaskResult.Value;
            Dictionary<long, Dictionary<string, object>> param = BuildDictionary(result.TrackedParameters.Parameters);

            long start = param.Keys.First();

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Series.Add("Position Error");
            chart1.Series.Add("Direction Error");
            chart1.Titles.Add(result.User.Name + " - " + scenarios[currentResult].Name);

            chart1.Titles.Add("Error over Time");
            chart1.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);
            chart1.Titles[1].Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.ChartAreas[0].AxisX.Title = "Time (seconds)";
            chart1.ChartAreas[0].AxisY.Title = "Error (%)";


            foreach (KeyValuePair<long, Dictionary<string, object>> p in param)
            {
                float posError = Vector3f.DistanceBetween(taskResult.Results[1].IdealValue, (Vector3f)p.Value["Tip Position"]);
                float posInitialError = Vector3f.DistanceBetween(taskResult.Results[1].IdealValue, (Vector3f)param[start]["Tip Position"]);
                float posNormalizedError = 100 * (1 - (posInitialError - posError) / posInitialError);

                float error = Vector3f.AngleBetween(taskResult.Results[0].IdealValue, (Vector3f)p.Value["Tool Direction"]);
                float initialError = Vector3f.AngleBetween(taskResult.Results[0].IdealValue, (Vector3f)param[start]["Tool Direction"]);
                float normalizedError = 100 * (1 - (initialError - error) / initialError);

                chart1.Series[0].Points.AddXY((1.0 * p.Key - start) / TimeSpan.TicksPerSecond, posNormalizedError);
                chart1.Series[1].Points.AddXY((1.0 * p.Key - start) / TimeSpan.TicksPerSecond, normalizedError);
            }

            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[1].ChartType = SeriesChartType.Line;
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[1].BorderWidth = 3;

            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            chart1.ChartAreas[0].AxisX.StripLines.Clear();

            int prevId = 0;

            List<IEventEnactor> enactors = new List<IEventEnactor>();
            playback = new ScenarioPlayback(result, new NullEntityPlacer());

            for (int i = 1; i < 12; i++)
                playback.EnqueueEnactor(new EventEnactor(this) { EventId = i });

            foreach (ScenarioEvent e in result.Events)
            {
                if (e.Id == prevId)
                    continue;

                chart1.ChartAreas[0].AxisX.StripLines.Add(new StripLine()
                    {
                        BorderDashStyle = ChartDashStyle.Solid,
                        BorderColor = Color.DarkBlue,
                        Interval = 0,
                        IntervalOffset = (1.0 * e.Timestamp.Ticks - start) / TimeSpan.TicksPerSecond,
                        Text = e.Name
                    });
                prevId = e.Id;
            }

            DrawEventStripLine();

            listView2.Items.Clear();
            foreach (EventParameter p in parameters[currentResult])
                listView2.Items.Add(p.Name).SubItems.AddRange(new string[] { p.Value.ToString() });
        }

        private Entity GetEntity(List<Entity> entities, string name)
        {
            return (from Entity e in entities
                    where e.Name == name
                    select e).First();
        }

        private Dictionary<long, Dictionary<string, object>> BuildDictionary(List<TrackedEventParameter> parameters)
        {
            Dictionary<long, Dictionary<string, object>> result = new Dictionary<long, Dictionary<string, object>>();

            foreach (TrackedEventParameter p in parameters)
            {
                if (result.ContainsKey(p.Timestamp.Ticks))
                {
                    result[p.Timestamp.Ticks].Add(p.Parameter.Name, p.Parameter.Value);
                }
                else
                {
                    result.Add(p.Timestamp.Ticks, new Dictionary<string, object>());
                    result[p.Timestamp.Ticks].Add(p.Parameter.Name, p.Parameter.Value);
                }
            }

            return result;
        }

        public void DrawEventStripLine()
        {
            if (chart1.InvokeRequired)
            {
                DrawEvent d = new DrawEvent(DrawEventStripLine);
                this.Invoke(d);
            }
            else
            {
                chart1.ChartAreas[0].AxisX.StripLines.Remove(eventStripLine);
                ScenarioEvent e = results[currentResult].Events[CurrentEvent];
                long start = results[currentResult].Events[0].Timestamp.Ticks;
                eventStripLine = new StripLine()
                {
                    BorderDashStyle = ChartDashStyle.Solid,
                    BorderColor = Color.Red,
                    Interval = 0,
                    IntervalOffset = (1.0 * e.Timestamp.Ticks - start) / TimeSpan.TicksPerSecond
                };
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(e.Name);
                builder.AppendLine(string.Format("{0} seconds", ((1.0 * e.Timestamp.Ticks - start) / TimeSpan.TicksPerSecond).ToString()));
                label1.Text = builder.ToString();
                chart1.ChartAreas[0].AxisX.StripLines.Add(eventStripLine);
            }
        }

        private void prevResult_Click(object sender, EventArgs e)
        {
            if (currentResult == 0)
                return;
            currentResult--;
            ChartData(results[currentResult]);
        }

        private void nextResult_Click(object sender, EventArgs e)
        {
            if (currentResult == results.Count - 1)
                return;
            currentResult++;
            ChartData(results[currentResult]);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;

            currentResult = listView1.SelectedIndices[0];

            ChartData(listView1.SelectedItems[0].Tag as SimulationResult);
        }

        public void nextEventButton_Click(object sender, EventArgs e)
        {
            playback.Next();
        }

        public void previousEventButton_Click(object sender, EventArgs e)
        {
            playback.Previous();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            playback.Play();
        }
    }

    public class NullEntityPlacer : IEntityPlacer
    {
        public void Place(Entity entity)
        {

        }
    }

    public class EventEnactor : IEventEnactor
    {
        Form1 form;

        public EventEnactor(Form1 form)
        {
            this.form = form;
        }

        public int EventId
        {
            get;
            set;
        }

        public void Enact(ScenarioEvent e)
        {
            form.DrawEventStripLine();
        }
    }
}
