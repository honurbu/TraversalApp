using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.DTOs;
using TraversalApp.Core.Entites;

namespace TraversalApp.Core.Services
{
    public interface IAppUserService 
    {
        Task<AppUserDto> CreateUserAsync(AppUserDto appUserDto);

    }
}
