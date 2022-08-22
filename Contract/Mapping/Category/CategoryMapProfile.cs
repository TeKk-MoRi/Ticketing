using AutoMapper;
using Contract.ViewModels.Category;
using Contract.ViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Mapping.Category
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Domain.Models.Ticket.Category, AddCategoryViewModel>().ReverseMap();
            CreateMap<Domain.Models.Ticket.Category, DeleteCategoryViewModel>().ReverseMap();
            CreateMap<Domain.Models.Ticket.Category, GetAllCategoryViewModel>().ReverseMap();
            CreateMap<Domain.Models.Ticket.Category, UpdateCategoryViewModel>().ReverseMap();
        }
    }
}
