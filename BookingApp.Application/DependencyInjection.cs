using System.Reflection;
using BookingApp.Application.Common.Behaviours;
using AspNetCore.ServiceRegistration.Dynamic;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddServicesOfType<IScopedService>();
            services.AddServicesOfType<ISingletonService>();
            services.AddServicesOfType<ITransientService>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            return services;
        }
    }
}
