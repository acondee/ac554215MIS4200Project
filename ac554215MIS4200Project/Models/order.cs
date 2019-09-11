using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ac554215MIS4200Project.Models
{
    public class order
    {
        public int orderID { get; set; }
        public int customerID { get; set; }
        public virtual  customer customer { get; set; }
        public DateTime orderDate { get; set; }
    }
}