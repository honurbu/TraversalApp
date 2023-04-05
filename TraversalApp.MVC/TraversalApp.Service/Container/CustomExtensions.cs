using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Repositories;
using TraversalApp.Core.Services;
using TraversalApp.Core.UnitOfWorks;
using TraversalApp.Repository.Repositories;
using TraversalApp.Repository.UnitOfWorks;
using TraversalApp.Service.Services;

namespace TraversalApp.Service.Container
{
    public static class CustomExtensions
    {
        public static void ContainerDependencies(this IServiceCollection builder)
        {

            builder.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repository Layer Dependency Injection
            builder.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.AddScoped(typeof(IDestinationRepository), typeof(DestinationRepository));
            builder.AddScoped(typeof(IFeatureRepository), typeof(FeatureRepository));
            builder.AddScoped(typeof(ISubAboutRepository), typeof(SubAboutRepository));
            builder.AddScoped(typeof(ITestimonialRepository), typeof(TestimonialRepository));
            builder.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
            builder.AddScoped(typeof(IAppUserRepository), typeof(AppUserRepository));
            builder.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
            builder.AddScoped(typeof(IGuideRepository), typeof(GuideRepository));

            // Service Layer Dependency Injection
            //builder.Services.AddScoped(typeof(IGenericService<TEntity, TDto>), typeof(GenericService<>));
            builder.AddScoped(typeof(IDestinationService), typeof(DestinationService));
            builder.AddScoped(typeof(IFeatureService), typeof(FeatureService));
            builder.AddScoped(typeof(ISubAboutService), typeof(SubAboutService));
            builder.AddScoped(typeof(ITestimonialService), typeof(TestimonialService));
            builder.AddScoped(typeof(ICommentService), typeof(CommentService));
            builder.AddScoped(typeof(IAppUserService), typeof(AppUserService));
            builder.AddScoped(typeof(IReservationService), typeof(ReservationService));
            builder.AddScoped(typeof(IGuideService), typeof(GuideService));
            builder.AddScoped(typeof(IExcelService), typeof(ExcelService));


        }
    }
}
