using AutoMapper.Internal.Mappers;
using Azure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.DTOs;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;
using TraversalApp.Core.UnitOfWorks;
using TraversalApp.Repository.UnitOfWorks;

namespace TraversalApp.Service.Services
{
    public class AppUserService : IAppUserService   
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppUserDto> CreateUserAsync(AppUserDto appUserDto)
        {
            var user = new AppUser
            {
                Email = appUserDto.Email,
                Name = appUserDto.Name,
                Surname = appUserDto.Surname,
                UserName = appUserDto.UserName,
            };
            var result = await _userManager.CreateAsync(user, appUserDto.Password);

            if(!result.Succeeded)
            {

                var errors = result.Errors.Select(e => e.Description).ToList();
                return appUserDto;
            }

            await _unitOfWork.CommitAsync();

            return appUserDto;
        }
    }
}


#region
//public async Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
//{
//    var user = new User
//    {
//        Email = createUserDto.Email,
//        UserName = createUserDto.UserName,
//    };

//    // Password hashing
//    var result = await _userManager.CreateAsync(user, createUserDto.Password);

//    if (!result.Succeeded)
//    {
//        var errors = result.Errors.Select(e => e.Description).ToList();
//        return Response<UserDto>.Fail(new ErrorDto(errors, true), 400);
//    }

//    await _unitOfWork.CommitAsync();

//    return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 200);
//}
#endregion