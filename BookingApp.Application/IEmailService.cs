using AspNetCore.ServiceRegistration.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application
{
    public interface IEmailService : ITransientService
    {
        Task<bool> Send(string message);
    }
}
