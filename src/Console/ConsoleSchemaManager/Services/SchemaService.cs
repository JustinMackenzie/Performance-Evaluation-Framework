using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
    }

    public class CreateSchemaRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ServerUrl { get; set; }
    }
}
