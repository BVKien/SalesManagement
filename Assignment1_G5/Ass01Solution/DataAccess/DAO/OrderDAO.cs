using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        // Bui Van Kien 
        // Using singleton design pattern 
        private static OrderDAO instance = null;
        public static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        // Bui Van Kien 
        // Get order list 
        public IEnumerable<Order> GetOrderList()
        {
            List<Order> orders;
            try
            {
                var eStoreContext = new eStoreContext();
                orders = eStoreContext.Orders
                    .Include(order => order.Member)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        // Bui Van Kien 
        // Get order list by member id 
        public IEnumerable<Order> GetOrderListByMemberId(int memberId)
        {
            List<Order> orders;
            try
            {
                var eStoreContext = new eStoreContext();
                orders = eStoreContext.Orders
                    .Where(order => order.MemberId == memberId)
                    .Include(order => order.Member)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        // Bui Van Kien
        // Get order by id 
        public Order GetOrderById(int orderId)
        {
            Order order = null;
            try
            {
                var eStoreContext = new eStoreContext();
                order = eStoreContext.Orders.SingleOrDefault(order => order.OrderId == orderId);

                if (order == null)
                {
                    throw new Exception("Not found OrderId");
                }

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Bui Van Kien 
        // Add new order 
        public void AddNewOrder(Order order)
        {
            try
            {
                var eStoreContext = new eStoreContext();
                eStoreContext.Orders.Add(order);
                eStoreContext.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw new Exception("The order is already exist" + ex.Message);
            }
        }

        // Bui Van Kien 
        // Update order 
        public void UpdateOrder(Order order)
        {
            try
            {
                var eStoreContext = new eStoreContext();
                eStoreContext.Entry<Order>(order).State = EntityState.Modified;
                eStoreContext.SaveChanges();
            } catch (Exception ex)
            {
                throw new Exception("The order does not exist" + ex.Message);
            }
        }

        // Bui Van Kien 
        // Remove order 
        public void RemoveOrder(Order order)
        {
            try
            {
                var eStoreContext = new eStoreContext();
                eStoreContext.Orders.Remove(order);
                eStoreContext.SaveChanges();
            } 
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
