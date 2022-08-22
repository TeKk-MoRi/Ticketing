using AutoMapper;
using Contract.ViewModels.User;
using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Mapping.User
{
    public class UserMapprofile : Profile
    {
        public UserMapprofile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
            CreateMap<ApplicationUser, RegisterApplicationUserViewModel>().ReverseMap();
        }
    }
}
