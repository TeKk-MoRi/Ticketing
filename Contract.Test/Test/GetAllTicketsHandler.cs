using AutoMapper;
using Contract.Query.Ticket;
using Contract.ViewModels.Ticket;
using Domain.Models.Ticket;
using Moq;
using Service.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Contract.Test.Model.TicketModelTest;

namespace Contract.Test.Test
{
    public class GetAllTicketsHandler
    {
        private Mock<ITicketService> _service;
        private IMapper _mapper;
        public GetAllTicketsHandler()
        {
            _service = new Mock<ITicketService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Domain.Models.Ticket.Ticket, GetAllTicketsViewModel>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

        }


        [Theory]
        [ClassData(typeof(TicketModelRequestTest))]
        //naming convention MethodName_expectedBehavior_StateUnderTest
        public async Task GetAllTicketsHandler_GetTicketsByOwnerId_ShouldReturnListOfTickets(GetAllTicketsQuery req)
        {

            _service.Setup(x => x.GetAllTicketsByOwenrId(It.IsAny<string>()))
                .ReturnsAsync(GetSampleData);

            var handler = new Contract.Handle.Ticket.GetAllTicketsHandler(_service.Object, _mapper);
            var res = await handler.Handle(req, CancellationToken.None);

            Assert.NotNull(res);
            Assert.True(res.IsSucceed);
            Assert.Equal(2, res.Result.Count);

        }
        private List<Domain.Models.Ticket.Ticket> GetSampleData()
        {
            List<Ticket> output = new();
            output.Add(new Ticket
            {
                Id = 1,
                Title = "My ticket",
                Body = "My ticket body"
            });

            output.Add(new Ticket
            {
                Id = 2,
                Title = "Your ticket",
                Body = "Your Ticket body"
            });

            return output;
        }
    }
}
