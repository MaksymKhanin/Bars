using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARS.Models
{
    public class OperationViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public double Amount { get; set; }
        public int BillFromId { get; set; }
        public int? BillToId { get; set; }
        public string BillFromName { get; set; }
        public string BillToName { get; set; }
        public string OrganisationFromName { get; set; }
        public string OrganisationToName { get; set; }

    }
}