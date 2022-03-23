

using System.ComponentModel.DataAnnotations;

namespace CinemaTicket.Models
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "Genre")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
