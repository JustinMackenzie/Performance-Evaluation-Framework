using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;
using System.IO;

namespace ScenarioSim.Simulator
{
    class CsvTaskResultLogger : ITaskResultLogger
    {
        string filename;

        public void LogTaskResult(TreeNode<TaskResult> result, string filename)
        {
            this.filename = string.Format("{0}.csv", filename);
            result.Traverse(LogTaskResult);
        }

        private void LogTaskResult(TaskResult task)
        {
            using (StreamWriter writer = File.AppendText(filename))
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("{0},{1}", task.TaskName, (1.0 * task.Speed / TimeSpan.TicksPerSecond));
                
                foreach(AccuracyMetricResult metricResult in task.Results)
                {
                    builder.AppendFormat(",{0},{1},{2}", metricResult.IdealValue, metricResult.ActualValue, metricResult.Error);
                }

                writer.WriteLine(builder.ToString());
            }
        }

    }
}
