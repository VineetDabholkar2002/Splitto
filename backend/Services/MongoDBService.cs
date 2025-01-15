using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using backend.Models;

namespace backend.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;
        public MongoDbService(IConfiguration configuration)
        {
            // Retrieve connection string from appsettings.json
            _configuration = configuration;
            var connectionString = configuration.GetConnectionString("MongoDB");
            var mongoURL = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoURL);
            _database = mongoClient.GetDatabase(mongoURL.DatabaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

    }
}
