using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.DTOs;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Repositories;
using TraversalApp.Core.Services;
using TraversalApp.Core.UnitOfWorks;
using TraversalApp.Repository.Repositories;
using TraversalApp.Repository.UnitOfWorks;
using TraversalApp.Service.Services;
using TraversalApp.Service.Validations;

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
            builder.AddScoped(typeof(IContactUsRepository), typeof(ContactUsRepository));
            builder.AddScoped(typeof(IAnnouncementRepository), typeof(AnnouncementRepository));


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
            builder.AddScoped(typeof(IContactUsService), typeof(ContactUsService));
            builder.AddScoped(typeof(IExcelService), typeof(ExcelService));
            builder.AddScoped(typeof(IAnnouncementService), typeof(AnnouncementService));


        }



        public static void CustomValidator(this IServiceCollection builder)
        {
            builder.AddSingleton<IValidator<AppUserDto>, AppUserValidator>();
            builder.AddSingleton<IValidator<Guide>, GuideValidator>();
            builder.AddSingleton<IValidator<About>, AboutValidator>();
            builder.AddSingleton<IValidator<AnnouncementDto>, AnnouncementValidator>();

        }


    }
}
