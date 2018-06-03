using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderingSystem.Models
{
    public class OrderedFoood 
    {
        [Key][Column(Order = 0)]
        public int MenuId { get; set; }

        [Key][Column(Order = 1)]
        public int EmployeeOrderId { get; set; }

        public int Quantity { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual EmployeeOrder EmployeeOrder { get; set; }
    }
}