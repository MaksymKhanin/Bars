using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARS.Models
{
    public class BillViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double BookedAmount { get; set; }
        public double FreeAmount { get { return (Amount - BookedAmount); } set { } }
        public int OrganisationId { get; set; }
        public string OrganisationName { get; set; }
        public string OrganisationType { get; set; }
    }
}