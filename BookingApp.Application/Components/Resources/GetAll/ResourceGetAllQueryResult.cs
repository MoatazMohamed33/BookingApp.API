using AutoMapper;
using BookingApp.Application.Common.Mappings;
using BookingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Components.Resources.GetAll
{
    public class ResourceGetAllQueryResult : IMapFrom<Resource>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Resource, ResourceGetAllQueryResult>();
        }
    }
}
