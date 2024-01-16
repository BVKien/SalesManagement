using DataAccess.DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Objects
{
    public class OrderDetailObject
    {
        private readonly IOrderDetailRepository repository;
        public OrderDetailObject(IOrderDetailRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<OrderDetail> GetOrderDetailList() => repository.GetOrderDetailList();
    }
}
