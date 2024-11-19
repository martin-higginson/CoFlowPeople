using AutoMapper;
using CoFlowPeople.Server.Models.Data;
using CoFlowPeople.Server.Models.Dtos;
using CoFlowPeople.Server.Models.Service;

namespace CoFlowPeople.Server.Models.AutoMap
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Person, PersonModel>();
            CreateMap<PersonModel,Person> ();
            CreateMap<PersonDto, PersonModel> ();
        }
    }
}
