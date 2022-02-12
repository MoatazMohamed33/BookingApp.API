using BookingApp.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Components.Resources.GetAll
{
    public class ResourceGetAllQuery : IRequest<OutputResponse<List<ResourceGetAllQueryResult>>>
    {
    }
}
