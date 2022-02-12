using AutoMapper;
using BookingApp.Application;
using BookingApp.Application.Common.Responses;
using BookingApp.Application.Components.Resources.Get;
using BookingApp.Application.Components.Resources.GetAll;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Components
{
    public class ResourceService : IResourceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ResourceService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Exists(int id, CancellationToken token)
        {
            return await _context.Resources.AnyAsync(c => c.Id == id);
        }

        public async Task<OutputResponse<ResourceGetQueryResult>> Get(ResourceGetQuery request)
        {
            var res = await _context.Resources.Include(a => a.Booking).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            var result = _mapper.Map<ResourceGetQueryResult>(res);
            return new OutputResponse<ResourceGetQueryResult>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Success",
                Model = result
            };
        }

        public async Task<OutputResponse<List<ResourceGetAllQueryResult>>> GetAll(ResourceGetAllQuery request)
        {
            var res = await _context.Resources.ToListAsync();
            var result = _mapper.Map<List<ResourceGetAllQueryResult>>(res);
            return new OutputResponse<List<ResourceGetAllQueryResult>>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Success",
                Model = result
            };
        }
    }
}
