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
    public class FeatureService : GenericServices<Feature>, IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IGenericRepository<Feature> repository, IUnitOfWork unitOfWork, IFeatureRepository featureRepository) : base(repository, unitOfWork)
        {
            _featureRepository = featureRepository;
        }
    }
}
