using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.API.Factory
{
    public interface IServiceSetup
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
