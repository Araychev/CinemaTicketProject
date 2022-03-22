
using CinemaTicket.Infrastructure.Data.Common;

namespace CinemaTicket.Infrastructure.Data.Repositories
{
    internal interface IApplicatioDbRepository<T> : IRepository<T> where T : class
    {
        
    }
}
