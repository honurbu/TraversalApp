using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Reflection;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Repositories;
using TraversalApp.Core.Services;
using TraversalApp.Core.UnitOfWorks;
using TraversalApp.Repository.Context;
using TraversalApp.Repository.Repositories;
using TraversalApp.Repository.UnitOfWorks;
using TraversalApp.Service.Mapping;
using TraversalApp.Service.Services;
using TraversalApp.Core.DTOs;
using TraversalApp.Service.Validations;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Repository Layer Dependency Injection
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IDestinationRepository), typeof(DestinationRepository));
builder.Services.AddScoped(typeof(IFeatureRepository), typeof(FeatureRepository));
builder.Services.AddScoped(typeof(ISubAboutRepository), typeof(SubAboutRepository));
builder.Services.AddScoped(typeof(ITestimonialRepository), typeof(TestimonialRepository));
builder.Services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
builder.Services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));

// Service Layer Dependency Injection
//builder.Services.AddScoped(typeof(IGenericService<TEntity, TDto>), typeof(GenericService<>));
builder.Services.AddScoped(typeof(IDestinationService), typeof(DestinationService));
builder.Services.AddScoped(typeof(IFeatureService), typeof(FeatureService));
builder.Services.AddScoped(typeof(ISubAboutService), typeof(SubAboutService));
builder.Services.AddScoped(typeof(ITestimonialService), typeof(TestimonialService));
builder.Services.AddScoped(typeof(ICommentService), typeof(CommentService));
builder.Services.AddScoped(typeof(IAppUserService), typeof(AppUserService));
builder.Services.AddScoped(typeof(IReservationService), typeof(ReservationService));


builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddSingleton<IValidator<AppUserDto>, AppUserValidator>();
builder.Services.AddControllersWithViews().AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblyContaining<Program>();
});

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDbContext"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<AppDbContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(config =>
    {
        var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
    });

builder.Services.AddMvc();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
