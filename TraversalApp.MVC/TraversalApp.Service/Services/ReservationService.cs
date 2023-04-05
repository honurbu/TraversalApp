using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Repositories;
using TraversalApp.Core.Services;
using TraversalApp.Core.UnitOfWorks;

namespace TraversalApp.Service.Services
{
    public class ReservationService : GenericServices<Reservation>, IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IGenericRepository<Reservation> repository, IUnitOfWork unitOfWork, IReservationRepository reservationRepository) : base(repository, unitOfWork)
        {
            _reservationRepository= reservationRepository;
        }


        public List<Reservation> GetApprovalReservationByAccepted(int id)
        {
            return _reservationRepository.GetApprovalReservationByAccepted(id);
        }

        public List<Reservation> GetApprovalReservationByPrevious(int id)
        {
            return _reservationRepository.GetApprovalReservationByPrevious(id);
        }

        public List<Reservation> GetApprovalReservationByWaitApproval(int id)
        {
            return _reservationRepository.GetApprovalReservationByWaitApproval(id);
        }
    }
}
