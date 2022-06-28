using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserMVCApp.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
