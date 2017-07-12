namespace ConsoleSchemaManager.Services
{
    public class CreateSchemaRequest : ApiRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}