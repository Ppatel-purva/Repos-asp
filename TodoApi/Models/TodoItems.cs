namespace TodoApi.Models
{
    public class TodoItems
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public bool IsComplete { get; set; }
    }
}
