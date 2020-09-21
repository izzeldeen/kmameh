using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedServices.IService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokerService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerBasketService _basketService;
        public OrderController(UserManager<User> userManager, SignInManager<User> signInManager
            , ITokenService tokenService, IMapper mapper , IUnitOfWork unitOfWork , ICustomerBasketService basketSerivce)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokerService = tokenService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _basketService = basketSerivce;
        }
        [HttpPost("CreateOrder")]

        public async Task<ActionResult> PostOrder(OrderDto orderDto)
        {
            var basket = await _basketService.GetBasketAsync(orderDto.BasketId);
            return  Ok(await _unitOfWork.OrderService.CreateOrder(orderDto.BuyerEmail, orderDto.BuyerName, orderDto.lat, orderDto.lng, basket));

        }
    }
}
