using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        // Bui Van Kien 
        // Using singleton design pattern 
        private static OrderDetailDAO instance = null;
        public static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        // Bui Van Kien 
        // Get order details list by order id 
        public IEnumerable<OrderDetail> GetOrderDetailListByOrderId(int orderId)
        {
            List<OrderDetail> orderDetails;
            try
            {
                var eStoreContext = new eStoreContext();
                orderDetails = eStoreContext.OrderDetails
                    .Where(od => od.OrderId == orderId)
                    .Include(od => od.Product)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        // Bui Van Kien 
        // Get order list 
        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> orderDetails;
            try
            {
                var eStoreContext = new eStoreContext();
                orderDetails = eStoreContext.OrderDetails
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        // Bui Van Kien
        // Get order by id 
        public OrderDetail GetOrderDetailById(int orderDetailId)
        {
            OrderDetail orderDetail = null;
            try
            {
                var eStoreContext = new eStoreContext();
                orderDetail = eStoreContext.OrderDetails.SingleOrDefault(od => od.OrderDetailId == orderDetailId);

                if (orderDetail == null)
                {
                    throw new Exception("Not found OrderDetailId");
                }

                return orderDetail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Bui Van Kien 
        // Add new order detail 
        public void AddNewOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var eStoreContext = new eStoreContext();
                eStoreContext.OrderDetails.Add(orderDetail);
                eStoreContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("The order detail is already exist" + ex.Message);
            }
        }

        // Bui Van Kien 
        // Update order detail 
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var eStoreContext = new eStoreContext();
                eStoreContext.Entry<OrderDetail>(orderDetail).State = EntityState.Modified;
                eStoreContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("The order detail does not exist" + ex.Message);
            }
        }

        // Bui Van Kien 
        // Remove order detail 
        public void RermoveOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var eStoreContext = new eStoreContext();
                eStoreContext.OrderDetails.Remove(orderDetail);
                eStoreContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
