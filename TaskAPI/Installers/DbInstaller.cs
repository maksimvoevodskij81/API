using BackendData;
using BackendData.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using TaskAPI.Interfaces;
using TaskAPI.Services;

namespace TaskAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=database.sqlite;Cache=Shared";
            services.AddSqlite<AppDbContext>(connectionString);
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IAddressService, AddressService>();
            services.AddIdentityCore<IdentityUser>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<AppDbContext>();

        }
    }
}
