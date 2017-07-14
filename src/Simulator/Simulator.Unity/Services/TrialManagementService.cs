using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Simulator.Unity.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Simulator.Unity.Services.ITrialManagementService" />
    public class TrialManagementService : ITrialManagementService
    {
        /// <summary>
        /// The base URL
        /// </summary>
        private readonly string baseUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialManagementService"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        public TrialManagementService(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        /// <summary>
        /// Adds the trial.
        /// </summary>
        /// <param name="trial">The trial.</param>
        public void AddTrial(Trial trial)
        {
            string url = string.Format("{0}/api/Trial", this.baseUrl);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "POST";

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(trial);

                writer.Write(json);
                writer.Flush();
                writer.Close();
            }
        }
    }
}