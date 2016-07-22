using System;
using System.Collections.Generic;
using System.Net.Http;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.HttpClientRepositories
{
    public abstract class HttpClientEntityRepository<T> : IEntityRepository<T> where T : Entity
    {
        /// <summary>
        /// The base URL
        /// </summary>
        protected string BaseUrl;

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        /// <value>
        /// The name of the resource.
        /// </value>
        protected abstract string ResourceName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientEntityRepository{T}"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        protected HttpClientEntityRepository(string baseUrl)
        {
            this.BaseUrl = baseUrl;
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T Get(Guid id)
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.GetAsync($"{BaseUrl}/api/{ResourceName}/{id}");
                string result = task.Result.Content.ReadAsStringAsync().Result;
                return JsonNetSerializer.JsonNetSerializer.DeserializeObject<T>(result);
            }
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                var task = client.GetAsync($"{BaseUrl}/api/{ResourceName}");
                string result = task.Result.Content.ReadAsStringAsync().Result;
                return JsonNetSerializer.JsonNetSerializer.DeserializeObject<IEnumerable<T>>(result);
            }
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(T entity)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DeleteAsync($"{BaseUrl}/api/{ResourceName}/{entity.Id}");
            }
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Save(T entity)
        {
            T existing = Get(entity.Id);

            using (HttpClient client = new HttpClient())
            {
                string json = JsonNetSerializer.JsonNetSerializer.SerializeObject(entity);
                HttpContent content = new StringContent(json);

                if (existing != null)
                    client.PutAsync($"{BaseUrl}/api/{ResourceName}/{existing.Id}", content);
                else
                    client.PostAsync($"{BaseUrl}/api/{ResourceName}", content);
            }
        }
    }
}
