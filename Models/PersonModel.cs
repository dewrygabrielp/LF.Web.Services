using System;
using System.Collections.Generic;

namespace LF.Web.Services.Models
{
    public partial class PersonModel
    {
        public int PersonId { get; set; }
        public string NameField { get; set; }
        public int? AgeField { get; set; }
    }
}
