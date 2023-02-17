using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Solution.Data.Entities;
using Solution.Data.Models.Query;
using Solution.Data.Models.UserModels;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UsersController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult<LiteUserDto>> GetCurrentUser()
        {
            var token = Request.Headers.Authorization.ToString();
            if (!token.IsNullOrEmpty())
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var userInfo = tokenHandler.ReadJwtToken(token);
                var userName = userInfo.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;

                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    return Ok(_mapper.Map<LiteUserDto>(user));
                }
            }
            
            return NotFound("Not exist user.");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[Action]")]
        public async Task<ActionResult<List<LiteUserDto>>> GetAllUsers()
        {
            var userList = await _userManager.Users.ToListAsync();
            return Ok(_mapper.Map<List<LiteUserDto>>(userList));
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("[Action]")]
        public async Task<ActionResult<List<LiteUserDto>>> GetUsersByPage([FromQuery] PaginationParameters parameters)
        {
            var validPagingatonParameters = new PaginationParameters(parameters.PageNumber, parameters.PageSize);

            var userList = await _userManager.Users
                .Skip(validPagingatonParameters.PageSize * (validPagingatonParameters.PageNumber - 1))
                .Take(validPagingatonParameters.PageSize)
                .ToListAsync();
            return Ok(_mapper.Map<List<LiteUserDto>>(userList));
        }

        [HttpPost]
        public async Task<ActionResult<LiteUserDto>> PostUser(RegisterUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(new User
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = "Customer"
            }, user.ConfirmPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(_mapper.Map<LiteUserDto>(user));
        }

        
    }
}
