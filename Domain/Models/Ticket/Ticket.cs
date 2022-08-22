using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Ticket
{
    public class Ticket
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string OwnerId { get; set; }
        public string OperatorId { get; set; }
        public bool IsClosed { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

        #region Relations
        [ForeignKey("OwnerId")]
        public ApplicationUser Owner { get; set; }
        [ForeignKey("OperatorId")]
        public ApplicationUser Operator { get; set; }

        public List<TicketCategory> TicketCategories { get; set; }
        #endregion
    }
}
