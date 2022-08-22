using Contract.Command.Category;
using Contract.Command.Ticket;
using Contract.Messaging.Category;
using Contract.Messaging.Ticket;
using Contract.Query.Category;
using Contract.ViewModels.Category;
using Contract.ViewModels.Ticket;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Extensions;

namespace Ticketing.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize(Roles = "CategoryAdmin")]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel model)
        {
            var res = await _mediator.Send(new AddCategoryCommand(new AddCategoryRequest { ViewModel = model }));

            return Response(res);
        }

        [HttpPost]
        [Authorize(Roles = "CategoryAdmin")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryViewModel model)
        {
            var res = await _mediator.Send(new DeleteCategoryCommand(new DeleteCategoryRequest { ViewModel = model }));

            return Response(res);
        }

        [HttpPost]
        [Authorize(Roles = "CategoryAdmin")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryViewModel model)
        {
            var res = await _mediator.Send(new UpdateCategoryCommand(new UpdateCategoryRequest { ViewModel = model }));

            return Response(res);
        }

        [HttpGet]
        [Authorize(Roles = "CategoryAdmin")]
        public async Task<IActionResult> GetAllCategories()
        {
            var res = await _mediator.Send(new GetAllCategoriesQuery());

            return Response(res);
        }
    }
}
