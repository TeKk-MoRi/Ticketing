using AutoMapper;
using Contract.Command.Category;
using Contract.Messaging.Category;
using Contract.ViewModels.Category;
using MediatR;
using Service.Core.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Domain.Models.Ticket;

namespace Contract.Handle.Category
{
    public class UpdateCategoryhandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
    {
        private readonly ICategoryService _categoryervice;
        private readonly IMapper _mapper;
        public UpdateCategoryhandler(ICategoryService categoryervice, IMapper mapper)
        {
            this._categoryervice = categoryervice;
            this._mapper = mapper;
        }
        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            UpdateCategoryResponse response = new();
            try
            {
                var categoryEntity = await _categoryervice.GetByIdAsync(request.Request.ViewModel.Id);
                if (categoryEntity is not null)
                {
                    Entity.Category category = _mapper.Map<UpdateCategoryViewModel, Entity.Category>(request.Request.ViewModel, categoryEntity);
                    var res = await _categoryervice.UpdateAndSaveAsync(category);

                    if (res != 0)
                    {
                        response.Result = true;
                        response.Succeed();
                        response.SuccessMessage();
                        return response;
                    }
                }
                response.Failed();
                response.FailedMessage();
                response.FailedMessage("Not Found");
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
