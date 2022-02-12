using AutoMapper;

namespace BookingApp.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
