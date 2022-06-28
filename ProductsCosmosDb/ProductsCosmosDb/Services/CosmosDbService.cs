using ProductsCosmosDb.Models;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsCosmosdb.Services;

namespace ProductsCosmosDb.Services
{
    public class CosmosDbService : ICosmosDbService

    {
        private Container _container;


        public CosmosDbService(
            CosmosClient cosmosClient,
            string databaseName,
            string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);

        }
        public async Task AddAsync(Items item)
        {
            await _container.CreateItemAsync(item, new PartitionKey(item.Id));
        }
        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Items>(id, new PartitionKey(id));
        }

        public async Task<Items> GetItem(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Items>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Items>> GetMultipleAsync(string id)
        {
            var query = _container.GetItemQueryIterator<Items>();
            var results = new List<Items>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
        public async Task UpdateAsync(string id, Items item)
        {
            await _container.UpsertItemAsync(item, new PartitionKey(id));
        }

        
        Task<Items> ICosmosDbService.GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
