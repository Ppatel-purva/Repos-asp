using cosmosdb.Models;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cosmosdb.Services;


namespace cosmosdb.Services
{
    public class CosmosDbService : ICosmosDbServices

    {
        private Container _container;


        public CosmosDbService(
            CosmosClient cosmosClient,
            string databaseName,
            string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName,containerName);

        }
        public async Task AddAsync(Item item)
        {
            await _container.CreateItemAsync(item, new PartitionKey(item.Id));
        }
        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Item>(id, new PartitionKey(id));
        }

        public async Task<Item> GetItem(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Item>(id, new PartitionKey(id));
                    return response.Resource;
            }
            catch(CosmosException)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Item>> GetMultipleAsync(string id)
        {
            var query = _container.GetItemQueryIterator<Item>();
            var results = new List<Item>();

            while(query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
        public  async Task UpdateAsync(string id, Item item)
        {
            await _container.UpsertItemAsync(item, new PartitionKey(id));
        }

        Task<Item> ICosmosDbServices.GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
