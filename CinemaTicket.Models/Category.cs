using System.ComponentModel.DataAnnotations;

namespace CinemaTicket.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1,ErrorMessage = "{0} must be between {2} and {1} characters!")]
        public string Name { get; set; }

        [Range(1,100, ErrorMessage = "{0} must be between {1} and {2}")]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
