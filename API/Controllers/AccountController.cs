using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Dtos;
using API.Extensions;
using AutoMapper;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedServices.IService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokerService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager 
            , ITokenService tokenService , IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokerService = tokenService;
            _mapper = mapper;
        }

       [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserWithPictuerDto>> GetCurrentUser()
        {
          var user = await _userManager.FindEmailWithPictuerAsync(HttpContext.User);
          return  _mapper.Map<User,UserWithPictuerDto>(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return Unauthorized();
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if(user == null ) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user , loginDto.Password , false);
            if(!result.Succeeded) return Unauthorized();
            return new UserDto
            {
                DisplayName = user.UserName,
                Email = user.Email,
                Token = _tokerService.CreateToken(user)
            };         
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)

            => await _userManager.FindByEmailAsync(email) != null;

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto user)
        {
            if (!ModelState.IsValid) return null;

            if (await _userManager.FindByEmailAsync(user.Email) != null)
            {
                return Unauthorized("Email is Exisit");
            }
            var NewUser = _mapper.Map<RegisterDto, User>(user);
           var res= await _userManager.CreateAsync(NewUser, user.Password);
           if(!res.Succeeded) return Unauthorized();
            return new UserDto
            {
                DisplayName = user.UserName,
                Email = user.Email,
                Token = _tokerService.CreateToken(NewUser)
            };   
        }

       
    }
}
