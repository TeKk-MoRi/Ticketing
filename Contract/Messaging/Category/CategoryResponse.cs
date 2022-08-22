using Contract.Messaging.Base;
using Contract.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Messaging.Category
{
    public class AddCategoryResponse : BaseApiResponse<bool> { }
    public class DeleteCategoryResponse : BaseApiResponse<bool> { }
    public class UpdateCategoryResponse : BaseApiResponse<bool> { }
    public class GetAllCategoriesResponse : BaseApiResponse<List<GetAllCategoryViewModel>> { }
}
