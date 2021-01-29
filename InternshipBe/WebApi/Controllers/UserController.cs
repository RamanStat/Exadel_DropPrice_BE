﻿using BL.DTO;
using BL.Interfaces;
using BL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet("getUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            return Ok(_service.GetUserInfo(await _userManager.FindByNameAsync(User.Identity.Name)));
        }
    }
}
