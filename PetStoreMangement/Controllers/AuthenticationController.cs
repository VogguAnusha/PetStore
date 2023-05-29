﻿using BusinessLayer.DTO;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetStoreMangement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticateService _authenticationService;

        public AuthenticationController(IAuthenticateService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserLoginDto user)
        {
            IActionResult response = Unauthorized();
            var token = "";
            var _user = _authenticationService.AuthenticateUser(user);

            if (_user != null)
            {
                token = _authenticationService.GenerateToken();
                response = Ok(new { token = token });
                return response;
            }
            return response;
        }
    }
}
