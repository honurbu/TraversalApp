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
using TraversalApp.Core.Repositories;
using TraversalApp.Core.Services;
using TraversalApp.Core.UnitOfWorks;
using TraversalApp.Repository.Repositories;
using TraversalApp.Repository.UnitOfWorks;

namespace TraversalApp.Service.Services
{
    public class AppUserService : GenericServices<AppUser>, IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(IGenericRepository<AppUser> repository, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IAppUserRepository appUserRepository) : base(repository, unitOfWork)
        {
            _appUserRepository = appUserRepository;
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

            if (!result.Succeeded)
            {

                var errors = result.Errors.Select(e => e.Description).ToList();
                return appUserDto;
            }

            await _unitOfWork.CommitAsync();

            return appUserDto;
        }
    }
}


