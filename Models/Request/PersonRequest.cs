using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LF.Web.Services.Models.Request
{
    public class PersonRequest
    {
        public int PersonId { get; set; }
        public string NameField { get; set; }
        public int? AgeField { get; set; }
    }
}
