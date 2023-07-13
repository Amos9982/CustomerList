using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomerList.Models
{
    public class Customer
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? Address { get; set; }

        [Required]
        public string? IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}