using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAppCosmosdb
{
    internal class Users
    {
        [JsonProperty(PropertyName  ="id")]
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Discription { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
