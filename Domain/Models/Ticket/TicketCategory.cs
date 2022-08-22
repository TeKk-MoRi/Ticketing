using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Ticket
{
    public class TicketCategory
    {
        [Key]
        public long Id { get; set; }
        public long TicketId { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        #endregion

    }
}
