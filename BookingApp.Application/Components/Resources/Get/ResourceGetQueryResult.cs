using AutoMapper;
using BookingApp.Application.Common.Mappings;
using BookingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Components.Resources.Get
{
    public class ResourceGetQueryResult : IMapFrom<Resource>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Resource, ResourceGetQueryResult>()
               .ForMember(r => r.DateFrom, opt => opt.MapFrom(c => c.Booking.DateFrom))
               .ForMember(r => r.DateTo, opt => opt.MapFrom(c => c.Booking.DateTo));
        }
    }
}
