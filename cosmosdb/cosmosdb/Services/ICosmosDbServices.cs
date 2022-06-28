using cosmosdb.Models;
using cosmosdb.Services;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace cosmosdb.Services
{
    public interface ICosmosDbServices
    {
        Task<IEnumerable<Item>> GetMultipleAsync(string id);

        Task<Item> GetAsync(string id);
        Task AddAsync(Item item);
        Task DeleteAsync(string id);
        Task UpdateAsync(string id, Item item);
    }
}
