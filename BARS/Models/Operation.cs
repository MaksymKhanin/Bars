using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BARS.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public double Amount { get; set; }

        [ForeignKey("BillFrom"), Column(Order = 0)]
        public int BillFromId { get; set; }
        [ForeignKey("BillTo"), Column(Order = 1)]
        public int? BillToId { get; set; }
        public Bill BillFrom { get; set; }
        public Bill BillTo { get; set; }



    }
}