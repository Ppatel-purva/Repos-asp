using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;
using CrudAppCosmosdb;

class Program
{
    static void Main(string[] args)
    {
        CosmosConnect cosmosConnect = new CosmosConnect();
        cosmosConnect.CreateDatabaseAsync().Wait();
        cosmosConnect.CreateContainerAsync().Wait();
        cosmosConnect.AddItemsToContainerAsync().Wait();
        cosmosConnect.QueryItemsAsync().Wait();
        cosmosConnect.ReplaceUserItemAsync().Wait();
        cosmosConnect.DeleteUserItemAsync().Wait();

    }
}

public class CosmosConnect
{
    private static readonly string EndpointURI = "https://localhost:8081";
    private static readonly string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";


    private CosmosClient cosmosClient;
    private Database database;
    private Container container;

    private string databaseId = "ProductDb";
    private string containerId = "ProductContainer";

    public CosmosConnect()
    {
        try
        {
            Console.WriteLine("Establish Connection...");
            this.cosmosClient = new CosmosClient(EndpointURI,PrimaryKey);
        }


        catch (CosmosException cosmosException)
        {
            Console.WriteLine($"CosmosDb exception {cosmosException.StatusCode}: {cosmosException} ");
        }

        catch (Exception e)
        {
            Console.WriteLine($"Error: {e}");
        }
    }

    public async Task CreateDatabaseAsync()
    {
        // Create a new database
        this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
        Console.WriteLine($"Created Database: {this.database.Id}");
    }

    public async Task CreateContainerAsync()
    {
        // Create a new container
        this.container = await this.database.CreateContainerIfNotExistsAsync(this.containerId, "/id");
        Console.WriteLine($"Created Container: {this.containerId}");


    }

    public async Task AddItemsToContainerAsync()
    {
        Users user = new Users
        {
            Id = "1",
            ProductName = "Pizza",
            Discription = "eat pizza and thao mota hahahah",
            Price = "700"
        };
        try
        {
            //Read the item to see if it exists
            ItemResponse<Users> pizza =await this.container.ReadItemAsync<Users>(user.Id,new PartitionKey(user.Id));
            Console.WriteLine("Item in database with id: {0} already exists\n",pizza.Resource.Id);
        }
        catch (CosmosException ex) when
        (ex.StatusCode == HttpStatusCode.NotFound)
        {
            // Create an item in the container representing the Andersen family. Note we provide the value of the partition key for this item, which is "Andersen"
            ItemResponse<Users> pizza =await this.container.CreateItemAsync<Users>(user,new PartitionKey(user.Id));

            // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
            Console.WriteLine($"Created item in database with id: {pizza.Resource.Id} Operation consumed {pizza.RequestCharge} RUs.\n");
        }
    }

    public async Task QueryItemsAsync()
    {
        var sqlQueryText = "SELECT * FROM c WHERE c.Username = 'pizza'";


        Console.WriteLine("Running query: {0}\n",sqlQueryText);
        QueryDefinition queryDefinition =new QueryDefinition(sqlQueryText);
        FeedIterator<Users> queryResultSetIterator =this.container.GetItemQueryIterator<Users>(queryDefinition);


        List<Users> users = new List<Users>();


        while (queryResultSetIterator.HasMoreResults)
        {
            FeedResponse<Users> currentResultSet =await queryResultSetIterator.ReadNextAsync();
            foreach (Users user in currentResultSet)
            {
                users.Add(user);
                Console.WriteLine($"\tRead {user}\n");
            }
        }

        //Console.WriteLine($"Total: {users.Count()}");

    }
    public async Task ReplaceUserItemAsync()
    {
        ItemResponse<Users> UsersResponse = await this.container.ReadItemAsync<Users>("1", new PartitionKey("1"));
        var itemBody = UsersResponse.Resource;


        // update FirstName
        itemBody.ProductName = "Pizza";

        // replace the item with the updated content
        UsersResponse = await this.container.
        ReplaceItemAsync<Users>(itemBody,
        itemBody.Id, new PartitionKey(itemBody.Id));
        Console.WriteLine($"Updated ProductName [" +
        $"{itemBody.ProductName},{itemBody.Id}].\n " +
        $"\tBody is now: {UsersResponse.Resource}\n");
    }
    public async Task DeleteUserItemAsync()
    {
        var partitionKeyValue = "2";
        var userId = "2";

        // Delete an item. Note we must provide the partition key value and id of the item to delete
        ItemResponse<Users> UsersResponse = await this.container.DeleteItemAsync<Users>(userId, new PartitionKey(partitionKeyValue));
        Console.WriteLine($"Deleted User [{partitionKeyValue},{userId}]\n");
    }
}

