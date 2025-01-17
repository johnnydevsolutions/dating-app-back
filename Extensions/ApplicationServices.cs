using back.Data;
using back.Helpers;
using back.Interfaces;
using back.Services;
using back.SignalR;
using DatingBack.Interfaces;
using DatingBack.Services;
using DatingProject.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingBack.Extensions
{
    public static class ApplicationServiceExtensions
    {
      public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
      {
        services.AddDbContext<DataContext>(options =>
        {
          options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenServices>();
        // services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.Configure <CloudinarySettings>(config.GetSection("CloudinarySettings"));
        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<LogUserActivity>();
        // services.AddScoped<ILikesRepository, LikesRepository>();
        // services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddSignalR();
        services.AddSingleton<PresenceTracker>();
        
        return services;
      }  
    }
}