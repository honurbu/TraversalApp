using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;

namespace TraversalApp.Core.Repositories
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        List<Reservation> GetApprovalReservationByWaitApproval(int id);
        List<Reservation> GetApprovalReservationByAccepted(int id);
        List<Reservation> GetApprovalReservationByPrevious(int id);

    }
}
