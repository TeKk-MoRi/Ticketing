using AutoMapper;
using Common.Helper;
using Contract.ViewModels.Ticket;
using Contract.ViewModels.User;
using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Mapping.Ticket
{
    public class TicketMapProfile : Profile
    {
        public TicketMapProfile()
        {
            CreateMap<Domain.Models.Ticket.Ticket, AddTicketViewModel>().ReverseMap();
            CreateMap<Domain.Models.Ticket.Ticket, GetAllTicketsViewModel>().ReverseMap();
            CreateMap<Domain.Models.Ticket.Ticket, TicketViewModel>().ReverseMap()                                                                                  
                .IgnoreMember(c => c.TicketCategories);
        }
    }
}
