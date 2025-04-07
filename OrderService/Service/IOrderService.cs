using OrderService.Model;

namespace OrderService.Service
{
    public interface IOrderService
    {
        void PlaceOrder(Order order);
    }
}
