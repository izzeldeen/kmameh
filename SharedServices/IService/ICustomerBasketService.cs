using System.Threading.Tasks;
using Core;

namespace SharedServices.IService
{
    public interface ICustomerBasketService : IService<CustomerBasket>
    {
         Task<CustomerBasket> GetBasketAsync(string basketId);

         Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

         Task<bool>  DeleteBasketAsync(string basketId);

         
    }
}