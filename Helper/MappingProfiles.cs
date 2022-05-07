using AutoMapper;
using DAWW.Dto;
using DAWW.Models;

namespace DAWW.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Produs, ProdusDto>();
            CreateMap<ProdusDto, Produs>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Achizitie, AchizitieDto>();
            CreateMap<AchizitieDto, Achizitie>();

            CreateMap<Achizitie, AchizitieDto2>();
            CreateMap<AchizitieDto2, Achizitie>();
        }
    }
}
