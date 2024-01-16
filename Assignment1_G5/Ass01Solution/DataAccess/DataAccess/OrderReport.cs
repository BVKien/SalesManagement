using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewObjects
{
    public class OrderReport
    {
        public OrderReport()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int Revenue { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
