using BookingApp.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Components.Resources.Get
{
    public class ResourceGetQuery : IRequest<OutputResponse<ResourceGetQueryResult>>
    {
        public int Id { get; set; }
    }
}
