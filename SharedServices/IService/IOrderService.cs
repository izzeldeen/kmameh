using Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices.IService
{
    public interface IOrderService : IService<Order>
    {
        Task<Order> CreateOrder(string BuyerEmail, string Name, double lat, double lng, CustomerBasket basket);
    }
}
