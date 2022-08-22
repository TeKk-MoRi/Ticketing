using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Ticket;
using Microsoft.AspNetCore.Identity;
namespace Domain.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsDeleted { get; set; }

        #region Relations
        [InverseProperty("Owner")]
        public List<Ticket.Ticket> Owners { get; set; }
        [InverseProperty("Operator")]
        public List<Ticket.Ticket> Operators { get; set; }
        #endregion
    }
}
