using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BARS.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double BookedAmount { get; set; }
        public double FreeAmount { get { return (Amount - BookedAmount); } }

        [ForeignKey("Organisation")]
        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }


        public ICollection<Operation> OperationsFrom { get; set; }
        public ICollection<Operation> OperationsTo { get; set; }
    }
}