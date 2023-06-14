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
    public class DestinationService : GenericServices<Destination>, IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;

        public DestinationService(IGenericRepository<Destination> repository, IUnitOfWork unitOfWork,IDestinationRepository destinationRepository) : base(repository, unitOfWork)
        {
            _destinationRepository = destinationRepository;
        }

        public Destination GetDestinationsWithGuide(int id)
        {
            return _destinationRepository.GetDestinationsWithGuide(id); 
        }
    }
}
