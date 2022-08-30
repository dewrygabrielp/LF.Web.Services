using System;
using System.Collections.Generic;

namespace LF.Web.Services.Models
{
    public partial class UserModel
    {
        public int UserId { get; set; }
        public string EmailField { get; set; }
        public string PasswordField { get; set; }
        public string NameField { get; set; }
        public int AgeField { get; set; }
        public string CreationDate { get; set; }
    }
}
