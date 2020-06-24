using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinesApi.Models;

namespace WinesApi.Services
{
    public class WineService
    {
        private readonly IMongoCollection<Wine> _wines;

        public WineService(IWineCellarDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _wines = database.GetCollection<Wine>(settings.WinesCollectionName);
        }

        public List<Wine> Get() =>
            _wines.Find(wine => true).ToList();

        public Wine Get(string id) =>
            _wines.Find<Wine>(wine => wine.Id == id).FirstOrDefault();

        public Wine Create(Wine wine)
        {
            _wines.InsertOne(wine);
            return wine;
        }

        public void Update(string id, Wine wineIn) =>
            _wines.ReplaceOne(wine => wine.Id == id, wineIn);

        public void Remove(Wine wineIn) =>
            _wines.DeleteOne(wine => wine.Id == wineIn.Id);

        public void Remove(string id) =>
            _wines.DeleteOne(wine => wine.Id == id);
    }
}
