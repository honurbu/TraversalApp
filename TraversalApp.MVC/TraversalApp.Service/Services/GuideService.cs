using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Repositories;
using TraversalApp.Core.Services;
using TraversalApp.Core.UnitOfWorks;
using TraversalApp.Repository.Repositories;

namespace TraversalApp.Service.Services
{
    public class GuideService : GenericServices<Guide>, IGuideService
    {
        private readonly IGuideRepository _guideRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GuideService(IGenericRepository<Guide> repository, IUnitOfWork unitOfWork, IGuideRepository guideRepository) : base(repository, unitOfWork)
        {
            _guideRepository = guideRepository;
            _unitOfWork = unitOfWork;
        }

        public async void ChangeToFalseByGuid(int id)
        {
            _guideRepository.ChangeToFalseByGuid(id);
            await _unitOfWork.CommitAsync();
        }

        public async void ChangeToTrueByGuid(int id)
        {
            _guideRepository.ChangeToTrueByGuid(id);
            await _unitOfWork.CommitAsync();
        }

    } 
}
