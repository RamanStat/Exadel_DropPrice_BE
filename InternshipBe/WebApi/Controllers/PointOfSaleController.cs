﻿using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    ///  Contains actions for working with points of sales
    /// </summary>
    [Route("api/pointOfSales")]
    [Authorize]
    public class PointOfSaleController : ControllerBase
    {
        private readonly IPointOfSaleService _pointOfSaleService;

        public PointOfSaleController(IPointOfSaleService pointOfSaleService)
        {
            _pointOfSaleService = pointOfSaleService;
        }

        /// <summary>
        /// Action to get all points of sales
        /// </summary>
        /// <returns>Returns points of sales</returns>
        [HttpGet]
        public async Task<IActionResult> GetPointOfSales()
        {
            return Ok(await _pointOfSaleService.GetPointOfSalesAsync());
        }
    }
}
