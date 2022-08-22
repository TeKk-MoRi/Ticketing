using Contract.Messaging.Base;
using Contract.ViewModels.Category;
using Contract.ViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Messaging.Category
{
    public class AddCategoryRequest : BaseApiRequest<AddCategoryViewModel> { }
    public class DeleteCategoryRequest : BaseApiRequest<DeleteCategoryViewModel> { }
    public class UpdateCategoryRequest : BaseApiRequest<UpdateCategoryViewModel> { }
}
