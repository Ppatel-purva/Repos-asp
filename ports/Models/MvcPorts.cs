using System;
using System.ComponentModel.DataAnnotations;


namespace ports.Models
{
    public class MvcPorts
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReachDate { get; set; }
        public string Location { get; set; }

        public decimal Fees { get; set; }
    }
}
