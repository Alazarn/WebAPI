using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [Route("api/authentification")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {        
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IAuthenticationManager authManager;
        public AuthenticationController(ILoggerManager logger, IMapper mapper, UserManager<User> userManager,
            IAuthenticationManager authManager)
        {            
            this.logger = logger;
            this.mapper = mapper;
            this.userManager = userManager;
            this.authManager = authManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = mapper.Map<User>(userForRegistration);
            var result = await userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await userManager.AddToRolesAsync(user, userForRegistration.Roles);
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await authManager.ValidateUser(user))
            {
                logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                
                return Unauthorized();
            }

            return Ok(new { Token = await authManager.CreateToken() });
        }
    }

}
