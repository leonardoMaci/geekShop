using GeekShop.OrderAPI.Model;

namespace GeekShop.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool status);
    }
}
