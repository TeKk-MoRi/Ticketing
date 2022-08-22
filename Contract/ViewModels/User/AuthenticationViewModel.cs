using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModels.User
{
    public class AuthenticationViewModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
