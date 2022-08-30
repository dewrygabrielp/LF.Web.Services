using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LF.Web.Services.Models.Request
{
    public class UserRequest
    {
        public int UserId { get; set; }
        public string EmailField { get; set; }
        public string PasswordField { get; set; }
        public string NameField { get; set; }
        public int AgeField { get; set; }
        public string CreationDate { get; set; }

    }
}
