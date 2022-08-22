using AutoMapper;
using Contract.Command.Category;
using Contract.Messaging.Category;
using Contract.Query.Category;
using Contract.ViewModels.Category;
using MediatR;
using Service.Core.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Handle.Category
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, GetAllCategoriesResponse>
    {
        private readonly ICategoryService _categoryervice;
        private readonly IMapper _mapper;
        public GetAllCategoriesHandler(ICategoryService categoryervice, IMapper mapper)
        {
            this._categoryervice = categoryervice;
            this._mapper = mapper;
        }
        public async Task<GetAllCategoriesResponse> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            GetAllCategoriesResponse response = new();

            try
            {
                var res = await _categoryervice.GetAllAsync();
                var viewModel = _mapper.Map<List<GetAllCategoryViewModel>>(res);

                response.Result = viewModel;
                response.Succeed();
                response.SuccessMessage();
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
