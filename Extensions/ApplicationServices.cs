using back.Data;
using back.Interfaces;
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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        return services;
      }  
    }
}