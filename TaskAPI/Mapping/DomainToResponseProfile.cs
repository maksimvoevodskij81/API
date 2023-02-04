using AutoMapper;
using BackendData.DomainModel;
using TaskAPI.Contracts.V1.Responses;

namespace TaskAPI.Mapping
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Address, AddressResponse>();
       }
    }
}
