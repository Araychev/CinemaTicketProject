using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicket.Models
{
    public class OrderDetail
    {
        public int Id {  get; set; }
        [Required]
        public int OrderId {  get; set; }
        [ForeignKey("OrderId")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        [ValidateNever]
        public Ticket Ticket { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
