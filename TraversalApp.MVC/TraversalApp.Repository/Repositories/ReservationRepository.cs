using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Repositories;
using TraversalApp.Repository.Context;

namespace TraversalApp.Repository.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }


        public List<Reservation> GetApprovalReservationByAccepted(int id)
        {
            return _context.Reservations.Include(x=>x.AppUser).Include(x => x.Destination).Include(y=>y.RStatus).Where(x=>x.RStatusId==2 && x.AppUserId == id).ToList();
        }

        public List<Reservation> GetApprovalReservationByPrevious(int id)
        {
            return _context.Reservations.Include(x => x.Destination).Include(y => y.RStatus).Where(x => x.RStatusId == 3 && x.AppUserId == id).ToList();
        }

        public List<Reservation> GetApprovalReservationByWaitApproval(int id)
        {
            return _context.Reservations.Include(x => x.Destination).Include(y=>y.RStatus).Where(x => x.RStatusId == 1 && x.AppUserId == id).ToList();
        }
    }
}
