using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Simulator.Unity.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ITrialSetManagementService" />
    public class TrialSetManagementService : ITrialSetManagementService
    {
        /// <summary>
        /// The base URL
        /// </summary>
        private readonly string baseUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetManagementService"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        public TrialSetManagementService(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        /// <summary>
        /// Gets the trial set by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TrialSet GetTrialSetById(Guid id)
        {
            string url = string.Format("{0}/api/TrialSet/{1}", this.baseUrl, id);
            return this.GetItem<TrialSet>(url);
        }

        /// <summary>
        /// Gets all trial sets.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TrialSet> GetAllTrialSets()
        {
            string url = string.Format("{0}/api/TrialSet", this.baseUrl);
            return this.GetItem<IEnumerable<TrialSet>>(url);
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private T GetItem<T>(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            string result = string.Empty;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                result = reader.ReadToEnd();

            T item = JsonConvert.DeserializeObject<T>(result);

            return item;
        }
    }
}
