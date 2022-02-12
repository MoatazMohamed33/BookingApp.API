using Microsoft.AspNetCore.Builder;

namespace BookingApp.API.Factory
{
    public interface IApplicationSetup
    {
        void SetupApplication(IApplicationBuilder app);
    }
}
