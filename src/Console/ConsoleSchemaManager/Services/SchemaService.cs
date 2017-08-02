using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleSchemaManager.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ConsoleSchemaManager.Services.ISchemaService" />
    public class SchemaService : ISchemaService
    {
        /// <summary>
        /// Creates the schema.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="Exception"></exception>
        public ApiResponse CreateSchema(CreateSchemaRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var response = client.PostAsync($"{request.ServerUrl}/api/Schema", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                return new ApiResponse(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Creates the schema event.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="Exception"></exception>
        public ApiResponse CreateSchemaEvent(CreateSchemaEventRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var response = client.PostAsync($"{request.ServerUrl}/api/Schema/{request.SchemaId}/Event", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                return new ApiResponse(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Creates the schema task.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="Exception"></exception>
        public ApiResponse CreateSchemaTask(CreateSchemaTaskRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var response = client.PostAsync($"{request.ServerUrl}/api/Schema/{request.SchemaId}/Task", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                return new ApiResponse(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Creates the task transition.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="Exception"></exception>
        public ApiResponse CreateTaskTransition(CreateTaskTransitionRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var response = client.PostAsync($"{request.ServerUrl}/api/Schema/{request.SchemaId}/TaskTransition", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                return new ApiResponse(response.Content.ReadAsStringAsync().Result);
            }
        }

        /// <summary>
        /// Creates the schema asset.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public ApiResponse CreateSchemaAsset(CreateSchemaAssetRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var response = client.PostAsync($"{request.ServerUrl}/api/Schema/{request.SchemaId}/Asset",
                    new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                return new ApiResponse(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
