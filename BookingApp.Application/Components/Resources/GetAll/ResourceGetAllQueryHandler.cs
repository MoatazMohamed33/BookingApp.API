using BookingApp.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingApp.Application.Components.Resources.GetAll
{
    public class ResourceGetAllQueryHandler : IRequestHandler<ResourceGetAllQuery, OutputResponse<List<ResourceGetAllQueryResult>>>
    {
        private readonly IResourceService _resourceService;
        public ResourceGetAllQueryHandler(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public Task<OutputResponse<List<ResourceGetAllQueryResult>>> Handle(ResourceGetAllQuery request, CancellationToken cancellationToken)
        {
            return _resourceService.GetAll(request);
        }
    }
}
