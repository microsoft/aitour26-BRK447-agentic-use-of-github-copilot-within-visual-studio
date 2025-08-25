using CartEntities;

namespace Store.Services;

public interface ICheckoutService
{
    Task<Order> ProcessOrderAsync(Customer customer, Cart cart);
    Task<Order> ProcessOrderAsync(Customer customer, Cart cart, string paymentMethod);
    Task<Order?> GetOrderAsync(string orderNumber);
}