
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using SharedServices.IService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController
    {
        private readonly ICustomerBasketService _basketService;
        private readonly IMapper _mapper;
        public BasketController(ICustomerBasketService basketService , IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("basket")]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
           var basket = await _basketService.GetBasketAsync(id);
           return basket ?? new CustomerBasket(id); 
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
           var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
           var updatedBasket =    await _basketService.UpdateBasketAsync(customerBasket);
           return customerBasket;
        } 
        [HttpDelete]
        public async Task DeleteBasketAsync(string id) => await _basketService.DeleteBasketAsync(id);

       
    }
}