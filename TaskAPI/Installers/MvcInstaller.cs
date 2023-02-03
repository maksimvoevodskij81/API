using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using TaskAPI.Filters;

namespace TaskAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options => options.Filters.Add<ValidationFilter>())
                .AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Program>());
            services.AddControllers();

        }
    }
}
