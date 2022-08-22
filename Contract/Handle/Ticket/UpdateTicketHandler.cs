using AutoMapper;
using Contract.Command.Ticket;
using Contract.Messaging.Ticket;
using Contract.ViewModels.Category;
using Contract.ViewModels.Ticket;
using MediatR;
using Service.Core.Ticket;
using Service.Core.TicketCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain.Models.Ticket;

namespace Contract.Handle.Ticket
{
    public class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand, UpdateTicketResponse>
    {
        private readonly ITicketService _ticketervice;
        private readonly ITicketCategoryService _ticketCategoryervice;
        private readonly IMapper _mapper;
        public UpdateTicketHandler(ITicketService ticketervice, IMapper mapper,
            ITicketCategoryService ticketCategoryervice)
        {
            this._ticketervice = ticketervice;
            this._mapper = mapper;
            this._ticketCategoryervice = ticketCategoryervice;
        }
        public async Task<UpdateTicketResponse> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            UpdateTicketResponse response = new();
            try
            {
                var ticket = await _ticketervice.GetByIdAsync(request.Request.ViewModel.Id);
                if (ticket is not null)
                {
                    Entity.Ticket ticketEntity = _mapper.Map(request.Request.ViewModel, ticket);
                    if (ticketEntity.OwnerId == request.Request.Owner)
                    {
                        var res = await _ticketervice.UpdateAndSaveAsync(ticketEntity);
                        if (res is not 0)
                        {
                            if (request.Request.ViewModel.TicketCategories is not null)
                            {
                                List<Entity.TicketCategory> ticketCategories = new();

                                foreach (var item in request.Request.ViewModel.TicketCategories)
                                {
                                    ticketCategories.Add(new Entity.TicketCategory
                                    {
                                        Id = item.Id,
                                        CategoryId = item.CategoryId,
                                        TicketId = ticket.Id,
                                    });
                                }
                                await _ticketCategoryervice.UpdateBulk(ticketCategories);
                            }

                            response.Result = true;
                            response.Succeed();
                            response.SuccessMessage();
                            return response;
                        }
                    }
                    else
                    {
                        response.Failed();
                        response.FailedMessage("Access denied");
                        return response;
                    }
                }

                response.Failed();
                response.FailedMessage();
                return response;
            }
            catch (Exception ex)
            {
                response.Failed();
                response.FailedMessage();
                response.FailedMessage(ex.Message);
                return response;
            }
        }
    }
}
