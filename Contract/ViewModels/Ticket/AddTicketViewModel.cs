using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModels.Ticket
{
    public class AddTicketViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public List<int> Categories { get; set; }
    }
}
