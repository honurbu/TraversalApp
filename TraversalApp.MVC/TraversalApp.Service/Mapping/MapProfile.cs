using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.DTOs;
using TraversalApp.Core.Entites;

namespace TraversalApp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser,AppUserDto>().ReverseMap();
        }
    }
}
