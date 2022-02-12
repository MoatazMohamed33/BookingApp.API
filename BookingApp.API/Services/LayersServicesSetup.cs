using BookingApp.Application;
using BookingApp.API.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.API.Services
{
    public class LayersServicesSetup : IServiceSetup
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterApplicationLayer(configuration);
        }
    }
}
