using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Repositories;
using TraversalApp.Core.Services;
using TraversalApp.Core.UnitOfWorks;
using TraversalApp.Repository.UnitOfWorks;

namespace TraversalApp.Service.Services
{
    public class ContactUsService : GenericServices<ContactUs>, IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactUsService(IGenericRepository<ContactUs> repository, IContactUsRepository contactUsRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _contactUsRepository = contactUsRepository;
            _unitOfWork = unitOfWork;

        }

        public async void ContactUsStatusChangeToFalse(int id)
        {
            _contactUsRepository.ContactUsStatusChangeToFalse(id);
            await _unitOfWork.CommitAsync();
        }

        public async void ContactUsStatusChangeToTrue(int id)
        {
            _contactUsRepository.ContactUsStatusChangeToTrue(id);
            await _unitOfWork.CommitAsync();
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            return _contactUsRepository.GetListContactUsByFalse();
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            return _contactUsRepository.GetListContactUsByTrue();
        }
    }
}
