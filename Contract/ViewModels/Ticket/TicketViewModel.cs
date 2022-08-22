using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModels.Ticket
{
    public class TicketViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<TicketCategoryViewModel> TicketCategories { get; set; }
    }
}
