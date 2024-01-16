using DataAccess.DataAccess;
using DataAccess.Repository;

namespace BusinessObject.Objects
{
    public class OrderObject
    {
        private readonly IOrderRepository repository;
        public OrderObject(IOrderRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Order> GetOrderListByMemberId(int memberId) => repository.GetOrderListByMemberId(memberId);
        public IEnumerable<Order> GetOrderList() => repository.GetOrderList();
    }
}
