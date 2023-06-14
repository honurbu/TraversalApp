using AutoMapper;
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
    public class AnnouncementService : GenericServices<Announcement>, IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IMapper _mapper;
        public AnnouncementService(IGenericRepository<Announcement> repository, IUnitOfWork unitOfWork, IAnnouncementRepository announcementRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _announcementRepository= announcementRepository;
            _mapper=mapper;
        }
    }
}
