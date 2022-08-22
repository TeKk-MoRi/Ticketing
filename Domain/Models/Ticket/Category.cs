using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Ticket
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public int? Parent { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }


        #region Relations
        [ForeignKey("Parent")]
        public Category SubCategory { get; set; }

        public List<TicketCategory> TicketCategories { get; set; }
        #endregion
    }
}
