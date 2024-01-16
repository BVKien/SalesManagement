using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetailListByOrderId(int orderId);
        IEnumerable<OrderDetail> GetOrderDetailList();
        OrderDetail GetOrderDetailById(int orderDetailId);
        void InsertOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(OrderDetail orderDetail);
    }
}
