using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using TrialSetManagement.Domain;

namespace TrialSetManagement.API.Application.Queries
{
    public class TrialSetQueries : ITrialSetQueries
    {
        public IEnumerable<TrialSetQueryDto> GetAllTrialSets()
        {
            IMongoClient client = new MongoClient("");
            IMongoDatabase db = client.GetDatabase("");

            IMongoCollection<TrialSetQueryDto> trialSetCollection = db.GetCollection<TrialSetQueryDto>("TrialSetProjection");

            return trialSetCollection.Find(t => true).ToEnumerable();
        }

        public TrialSetQueryDto GetTrialSetById(Guid id)
        {
            IMongoClient client = new MongoClient("");
            IMongoDatabase db = client.GetDatabase("");

            IMongoCollection<TrialSetQueryDto> trialSetCollection = db.GetCollection<TrialSetQueryDto>("TrialSetProjection");

            TrialSetQueryDto trialSet = trialSetCollection.Find(t => t.Id == id).SingleOrDefault();

            return trialSet;
        }
    }
}
