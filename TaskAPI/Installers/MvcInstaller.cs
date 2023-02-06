using FluentValidation;
using FluentValidation.AspNetCore;
using TaskAPI.Filters;
using TaskAPI.Interfaces;
using TaskAPI.Services;

namespace TaskAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options => options.Filters.Add<ValidationFilter>());
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ValidationFilter>();

            services.AddControllers();
           
            services.AddHttpContextAccessor();

            services.AddSingleton<IUriService>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext?.Request;
                var absoluteUri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent(), "/");
                return new UriService(absoluteUri);
            });

        }
    }
}
