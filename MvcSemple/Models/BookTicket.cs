using System;

namespace MvcSemple.Models
{
    public class BookTicket
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int NumberOfSets { get; set; }
        public DateTime ShowTime { get; set; }
    }
}
