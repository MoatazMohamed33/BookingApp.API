using BookingApp.Application;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Components
{
    public class EmailService : IEmailService
    {
        private readonly ILoggerFactory _loggerFactory;
        public EmailService(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public async Task<bool> Send(string message)
        {
            var logger = _loggerFactory.CreateLogger("EmailService");
            logger.LogInformation(message);
            return true;
        }
    }
}
