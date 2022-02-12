using AspNetCore.ServiceRegistration.Dynamic;
using BookingApp.Application.Common.Responses;
using BookingApp.Application.Components.Resources.Get;
using BookingApp.Application.Components.Resources.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingApp.Application
{
    public interface IResourceService : IScopedService
    {
        Task<OutputResponse<ResourceGetQueryResult>> Get(ResourceGetQuery request);
        Task<OutputResponse<List<ResourceGetAllQueryResult>>> GetAll(ResourceGetAllQuery request);
        Task<bool> Exists(int id, CancellationToken token);
    }
}
