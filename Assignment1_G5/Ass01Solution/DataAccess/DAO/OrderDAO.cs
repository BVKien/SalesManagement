using DataAccess.DataAccess;
using DataAccess.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO : eStoreContext
    {
        public List<OrderReport> GetOrderReport(DateTime fromDate, DateTime toDate)
        {
            using (var context = new eStoreContext())
            {
                var orderReports = context.Orders
                    .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                    .Select(o => new OrderReport
                    {
                        OrderDate = o.OrderDate,
                        ShippedDate = o.ShippedDate,
                        Revenue = o.OrderDetails.Sum(od => (od.UnitPrice * od.Quantity) - od.Discount),
                        OrderDetails = o.OrderDetails.Select(od => new OrderDetail
                        {
                            ProductId = od.ProductId,
                            Quantity = od.Quantity,
                            UnitPrice = od.UnitPrice,
                            Discount = od.Discount
                        }).ToList()
                    })
                    .ToList();

                return orderReports;
            }
        }
    }
}
