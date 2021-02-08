﻿using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/discounts")]
    [Authorize]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ITicketService _ticketService;
        private readonly UserManager<User> _userManager;

        public DiscountController(IDiscountService discountService, ITicketService ticketService, UserManager<User> userManager)
        {
            _discountService = discountService;
            _ticketService = ticketService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscounts(SortModel sortModel)
        {
            return Ok(await _discountService.GetDiscountsAsync(sortModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountById(int id, LocationModel locationModel)
        {
            return Ok(await _discountService.GetDiscountByIdAsync(id, locationModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchDiscounts(SearchModel searchmodel)
        {
            return Ok(await _discountService.SearchAsync(searchmodel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpGet("{id}/createTicket")]
        public async Task<IActionResult> CreateTicket(int id)
        {
            return Ok(await _ticketService.GetOrCreateTicketAsync(id, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpPut("{id}/save")]
        public async Task<IActionResult> SaveDiscount(int id)
        {
            return Ok(await _discountService.SaveOrUnsaveDisocuntAsync(id, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpPut("{id}/archive")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> ArchiveDiscount(int id)
        {
            return Ok(await _discountService.ArchiveOrUnarchiveDiscount(id, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
    }
}