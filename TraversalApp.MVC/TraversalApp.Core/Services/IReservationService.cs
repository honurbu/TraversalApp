using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;

namespace TraversalApp.Core.Services
{
    public interface IReservationService : IGenericService<Reservation>
    {
        IQueryable<Reservation> GetApprovalReservation(int id);

    }
}
