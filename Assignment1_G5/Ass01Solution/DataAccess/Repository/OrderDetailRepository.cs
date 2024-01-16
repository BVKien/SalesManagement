using DataAccess.DAO;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetOrderDetailListByOrderId(int orderId) 
            => OrderDetailDAO.Instance.GetOrderDetailListByOrderId(orderId);

        public IEnumerable<OrderDetail> GetOrderDetailList() 
            => OrderDetailDAO.Instance.GetOrderDetailList();
        public OrderDetail GetOrderDetailById(int orderDetailId) => OrderDetailDAO.Instance.GetOrderDetailById(orderDetailId);
        public void InsertOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddNewOrderDetail(orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.RermoveOrderDetail(orderDetail);
    }
}
