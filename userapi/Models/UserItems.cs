using Microsoft.EntityFrameworkCore;


namespace userapi.Models
{
    public class UserItems
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }

        public string Password { get; set; }
        public string Location { get; set; }
        public string date { get; set; }
        public bool IsComplete { get; set; }
    }
}
