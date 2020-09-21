using Core;
using DataAccess.Data;
using SharedServices.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly StoreContext _context;
     

        public OrderService(StoreContext context) : base(context)
        {
            _context = context;
        }

      

        

        public async Task<Order> CreateOrder(string BuyerEmail, string Name, double lat, double lng, CustomerBasket basket)
        {
            

            var items = new List<OrderItem>();
            foreach(var item in basket.Items)
            {
                var itemOrdered = new ProductITemOrder(item.Id, item.ProductName, item.ProductPictuer[0].Picture.URL);
                var orderItem = new OrderItem(itemOrdered, item.Price, item.Quantity);
                items.Add(orderItem);
            }
            var subtotal = items.Sum(item => item.Price * item.Quntity);
            Order NewOrder = new Order()
            {
                BuyerEmail = BuyerEmail,
                Name = Name,
                lat = lat,
                lng = lng,
                Subtotal = subtotal,
                OrderItems = items,
                ModifiedOn = DateTime.Now
            };

            _context.Orders.Add(NewOrder);
            await  _context.SaveChangesAsync();
            return NewOrder;     
        }

      
    }
}
