using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARS.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public int OrganisationId { get; set; }
    }
}