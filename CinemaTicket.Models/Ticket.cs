

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CinemaTicket.Models
{
    public class Ticket
    {
        [Key]
       public int Id { get; set; } 

       [Required]
       [MaxLength(100)]
       [Display(Name = "Title Of Movie")]
       public string TitleOfMovie { get; set; }

      
       public string Description { get; set; }

       [Required]
       [MaxLength(50)]
       public string Director { get; set; }

       
       [MaxLength(500)]
       public string? Actors { get; set; }

        [MaxLength(100)]
       public string? Country { get; set; }

        
        [MaxLength(100)]
        [Display(Name = "Original language")]
       public string? OriginalLanguage { get; set; }
       
       [MaxLength(1000)]
       [Required]
       [Display(Name = "Cinema")]
       public string CinemaName { get; set; }

       [MaxLength(1000)]
       [Required]
       [Display(Name = "Cinema Hall")]
       public string CinemaHall { get; set; }

       [MaxLength(100)]
       [Required]
       [Display(Name = "Projection Date and Time")]
       public string ProjectionDateAndTime { get; set; }

        [Required]
        [Range(1,10000)]
        [Display(Name = "List Price")]
        [Column(TypeName = "money")]
       public decimal ListPrice { get; set; }


        [Required]
        [Range(1,10000)]
        [Column(TypeName = "money")]
       public decimal Price { get; set; }

       [Required]
       [Range(1,10000)]
       [Column(TypeName = "money")]
       public decimal Price10 { get; set; }

       [Required]
       [Range(1,10000)]
       [Column(TypeName = "money")]
       public decimal Price20 { get; set; }
       
       [ValidateNever]
       public string ImageUrl { get; set; }

        [Required]
       public int CategoryId { get; set; }

       [ForeignKey(nameof(CategoryId))]
       [ValidateNever]
       public Category Category { get; set; }

       [Required]
       public int GenreId { get; set; }

       [ForeignKey(nameof(GenreId))]
       [ValidateNever]
       public Genre Genre{ get; set; }



    }
}
