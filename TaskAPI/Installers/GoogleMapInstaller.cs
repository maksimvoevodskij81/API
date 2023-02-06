using Microsoft.Extensions.Configuration;
using TaskAPI.Options;

namespace TaskAPI.Installers
{
    public class GoogleMapInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GoogleMapSettings>(configuration.GetSection(GoogleMapSettings.GoogleMap));

        }
    }
}
