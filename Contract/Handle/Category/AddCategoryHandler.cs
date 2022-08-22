using AutoMapper;
using Contract.Command.Category;
using Contract.Messaging.Category;
using MediatR;
using Service.Core.Category;
using Service.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain.Models.Ticket;

namespace Contract.Handle.Category
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, AddCategoryResponse>
    {
        private readonly ICategoryService _categoryervice;
        private readonly IMapper _mapper;
        public AddCategoryHandler(ICategoryService categoryervice, IMapper mapper)
        {
            this._categoryervice = categoryervice;
            this._mapper = mapper;
        }
        public async Task<AddCategoryResponse> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            AddCategoryResponse response = new();
            try
            {
                var category = _mapper.Map<Entity.Category>(request.Request.ViewModel);
                var res = await _categoryervice.AddAndSaveAsync(category);
                if (res != null)
                {
                    response.Result = true;
                    response.Succeed();
                    response.SuccessMessage();
                    return response;
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
