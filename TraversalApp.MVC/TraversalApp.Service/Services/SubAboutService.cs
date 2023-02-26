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
    public class SubAboutService : GenericServices<SubAbout>, ISubAboutService
    {
        private readonly ISubAboutRepository _subAboutRepository;

        public SubAboutService(IGenericRepository<SubAbout> repository, IUnitOfWork unitOfWork, ISubAboutRepository subAboutRepository) : base(repository, unitOfWork)
        {
            _subAboutRepository = subAboutRepository;
        }
    }
}
