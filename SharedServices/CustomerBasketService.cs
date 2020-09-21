using System;
using System.Text.Json;
using System.Threading.Tasks;
using Core;
using DataAccess.Data;
using SharedServices.IService;
using StackExchange.Redis;

namespace SharedServices
{
    public class CustomerBasketService : Service<CustomerBasket>, ICustomerBasketService
    {
        private readonly IDatabase _database;
       
        public CustomerBasketService(IConnectionMultiplexer redis , StoreContext context) : base(context)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
              return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
           var created = await _database.StringSetAsync(basket.Id , JsonSerializer.Serialize(basket) , TimeSpan.FromDays(30));
           if(!created) return null;

           return await GetBasketAsync(basket.Id);

        }
    }
}