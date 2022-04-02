using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTicket.Models;
using CinemaTicket.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace CinemaTicket.Core.Contracts
{
    public interface ITicketService
    {
        TicketVM GetTicketVM();

        Ticket GetTicketFirst(int? id);

        void AddTicket(TicketVM obj, IFormFile? file);
        void UpdateTicket(TicketVM obj, IFormFile? file);
        void SaveTicket();
        void DeleteTicket(Ticket obj);

        IEnumerable<Ticket> GetAll();

        
    }
}