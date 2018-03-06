using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARS.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int BillIdFrom { get; set; }
        public Bill BillFrom { get; set; }
        public int BillIdTo { get; set; }
        public Bill BillTo { get; set; }
        public int OrganisationIdFrom { get; set; }
        public int OrganisationIdTo { get; set; }


    }
}