using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Reflection;
using TraversalApp.Core.Repositories;
using TraversalApp.Core.Services;
using TraversalApp.Core.UnitOfWorks;
using TraversalApp.Repository.Context;
using TraversalApp.Repository.Repositories;
using TraversalApp.Repository.UnitOfWorks;
using TraversalApp.Service.Services;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Repository Layer Dependency Injection
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IDestinationRepository), typeof(DestinationRepository));
builder.Services.AddScoped(typeof(IFeatureRepository), typeof(FeatureRepository));
builder.Services.AddScoped(typeof(ISubAboutRepository), typeof(SubAboutRepository));
builder.Services.AddScoped(typeof(ITestimonialRepository), typeof(TestimonialRepository));

// Service Layer Dependency Injection
//builder.Services.AddScoped(typeof(IGenericService<TEntity, TDto>), typeof(GenericService<>));
builder.Services.AddScoped(typeof(IDestinationService), typeof(DestinationService));
builder.Services.AddScoped(typeof(IFeatureService), typeof(FeatureService));
builder.Services.AddScoped(typeof(ISubAboutService), typeof(SubAboutService));
builder.Services.AddScoped(typeof(ITestimonialService), typeof(TestimonialService));


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDbContext"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

// Add services to the container.
builder.Services.AddControllersWithViews();
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
