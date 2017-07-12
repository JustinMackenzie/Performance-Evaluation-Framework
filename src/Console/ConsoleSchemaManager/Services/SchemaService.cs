using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ConsoleSchemaManager.CommandHandlers;
using Newtonsoft.Json;

namespace ConsoleSchemaManager.Services
{
    public class SchemaService : ISchemaService
    {
        public void CreateSchema(CreateSchemaRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var response = client.PostAsync($"{request.ServerUrl}/api/Schema", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        public void CreateScenario(CreateScenarioRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var response = client.PostAsync($"{request.ServerUrl}/api/Schema/{request.SchemaId}/Scenario", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        public void CreateSchemaEvent(CreateSchemaEventRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var response = client.PostAsync($"{request.ServerUrl}/api/Schema/{request.SchemaId}/Event", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        public void CreateSchemaTask(CreateSchemaTaskRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(request);
                var response = client.PostAsync($"{request.ServerUrl}/api/Schema/{request.SchemaId}/Task", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
        }
    }
}
