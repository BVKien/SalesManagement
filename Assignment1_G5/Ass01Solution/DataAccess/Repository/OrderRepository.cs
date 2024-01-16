using DataAccess.DAO;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrderById(int orderId) => OrderDAO.Instance.GetOrderById(orderId);
        public IEnumerable<Order> GetOrderList() => OrderDAO.Instance.GetOrderList();
        public IEnumerable<Order> GetOrderListByMemberId(int memberId) => OrderDAO.Instance.GetOrderListByMemberId(memberId);
        public void InsertOrder(Order order) => OrderDAO.Instance.AddNewOrder(order);
        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
        public void DeleteOrder(Order order) => OrderDAO.Instance.RemoveOrder(order);
    }
}
