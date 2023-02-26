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
    public class TestimonialService : GenericServices<Testimonial>, ITestimonialService
    {
        private readonly ITestimonialRepository _tesimonialRepository;

        public TestimonialService(IGenericRepository<Testimonial> repository, IUnitOfWork unitOfWork, ITestimonialRepository testimonialRepository) : base(repository, unitOfWork)
        {
            _tesimonialRepository= testimonialRepository;
        }
    }
}
