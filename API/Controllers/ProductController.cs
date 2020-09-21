using System.Collections.Generic;
using System.Linq;
using API.Dtos;
using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using SharedServices.IService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

         [HttpGet("products")]
        public  IActionResult GetAllProducts(string? search , int CategoryId)
        {
            var products = _unitOfWork.Product.GetAllProduct(search , CategoryId);
            var productDto = _mapper.Map<IQueryable<Product>,List<ProductDto>>(products);
            return Ok(productDto);

        }

        [HttpGet("featuerProduct")]
       public IActionResult GetFeatuerProduct() 
       {
           var products = _unitOfWork.Product.GetFeatuerProduct();
           var productDto = _mapper.Map<IQueryable<Product>,List<ProductDto>>(products);
           return Ok(productDto);
       }

       [HttpGet("getlatestProduct")] 
       public IActionResult GetLatestProduct()
       {
           var products = _unitOfWork.Product.GetLatestProduct();
           var productDto = _mapper.Map<IQueryable<Product>,List<ProductDto>>(products);
           return Ok(productDto);
       }
        [HttpGet("getProductById")]
        public IActionResult GetProductById(int id) 
        {
           var latestproduct = _unitOfWork.Product.GetProductById(id);
           var lattestproductDto = _mapper.Map<Product , ProductDto>(latestproduct);
           return Ok(lattestproductDto);
        } 
        [HttpGet("getAllCategories")]
        public IActionResult GetAllCategories() => Ok(_unitOfWork.Category.GetAllCategories());


    }
}
