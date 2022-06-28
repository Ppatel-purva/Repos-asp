using ProductsCosmosdb.Services;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ProductsCosmosDb.Models;

namespace ProductsCosmosdb.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Items>> GetMultipleAsync(string id);

        Task<Items> GetAsync(string id);
        Task AddAsync(Items item);
        Task DeleteAsync(string id);
        Task UpdateAsync(string id, Items item);
    }
}
