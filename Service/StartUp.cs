using Microsoft.Extensions.DependencyInjection;
using Service.Base;
using Service.Core.Category;
using Service.Core.Identity;
using Service.Core.Ticket;
using Service.Core.TicketCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class StartUp
    {
        public static void Start(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITicketCategoryService, TicketCategoryService>();
        }
    }
}
