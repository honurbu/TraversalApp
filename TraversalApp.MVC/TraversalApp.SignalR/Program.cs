using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TraversalApp.SignalR.DAL;
using TraversalApp.SignalR.Hubs;
using TraversalApp.SignalR.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<VisitorService>();
//builder.Services.AddTransient<VisitorService>();
builder.Services.AddSignalR();

builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    }));

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<VisitorHub>("/VisitorHub");
    endpoints.MapControllers();
});

app.Run();
