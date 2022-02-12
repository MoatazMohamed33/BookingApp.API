using BookingApp.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingApp.Application.Components.Resources.Get
{
    public class ResourceGetQueryHandler : IRequestHandler<ResourceGetQuery, OutputResponse<ResourceGetQueryResult>>
    {
        private readonly IResourceService _resourceService;
        public ResourceGetQueryHandler(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }
        public Task<OutputResponse<ResourceGetQueryResult>> Handle(ResourceGetQuery request, CancellationToken cancellationToken)
        {
            return _resourceService.Get(request);
        }
    }
}
