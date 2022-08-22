using AutoMapper;
using Contract.Command.Ticket;
using Contract.Command.User;
using Contract.Messaging.Ticket;
using Contract.Messaging.User;
using MediatR;
using Service.Core.Category;
using Service.Core.Identity;
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
    public class AddTicketHandler : IRequestHandler<AddTicketCommand, AddTicketResponse>
    {
        private readonly ITicketService _ticketervice;
        private readonly ITicketCategoryService _ticketCategoryervice;
        private readonly IMapper _mapper;
        public AddTicketHandler(ITicketService ticketervice, IMapper mapper,
            ITicketCategoryService ticketCategoryervice)
        {
            this._ticketervice = ticketervice;
            this._mapper = mapper;
            this._ticketCategoryervice = ticketCategoryervice;
        }
        public async Task<AddTicketResponse> Handle(AddTicketCommand request, CancellationToken cancellationToken)
        {
            AddTicketResponse response = new();
            try
            {
                if (request.Request.ViewModel.Categories is not null && request.Request.ViewModel.Categories.Count > 0)
                {
                    Entity.Ticket ticketEntity = _mapper.Map<Entity.Ticket>(request.Request.ViewModel);
                    ticketEntity.OwnerId = request.Request.Owner;
                    ticketEntity.CreatedDate = DateTime.Now;
                    var res = await _ticketervice.AddAndSaveAsync(ticketEntity);
                    if (res is not null)
                    {
                        List<Entity.TicketCategory> ticketCategories = new();

                        foreach (var item in request.Request.ViewModel.Categories)
                        {
                            ticketCategories.Add(new Entity.TicketCategory
                            {
                                CategoryId = item,
                                TicketId = res.Id,
                            });
                        }
                        await _ticketCategoryervice.InsertBulk(ticketCategories);
                        response.Result = true;
                        response.Succeed();
                        response.SuccessMessage();
                        return response;
                    }
                }
                else
                {
                    response.FailedMessage("Category must not be empty");
                }
                response.Failed();
                response.FailedMessage();
                return response;
            }
            catch (Exception)
            {
                response.Failed();
                response.FailedMessage();
                response.FailedMessage("Please check if the category Ids are correct");
                return response;
            }
        }
    }
}
