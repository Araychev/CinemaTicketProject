

using System.ComponentModel.DataAnnotations;

namespace CinemaTicket.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; } 

        [Display(Name = "Genre")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
