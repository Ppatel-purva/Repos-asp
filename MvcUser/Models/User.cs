using System;
using System.ComponentModel.DataAnnotations;

namespace MvcUser.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        
        public string Location { get; set; }
        
       


    }
}
