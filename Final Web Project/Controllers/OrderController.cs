﻿using System;
using Final_Web_Project.Services.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Final_Web_Project.Services;
using Final_Web_Project.ViewModels.Order.Cart;
using Final_Web_Project.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Final_Web_Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IReceiptService receiptService;

        public OrderController(IOrderService orderService, IReceiptService receiptService)
        {
            this.orderService = orderService;
            this.receiptService = receiptService;
        }

        [HttpGet("Cart")]
        [Route("/Order/Cart")]
        [Authorize]
        public async Task<IActionResult> Cart()
        {
            List<OrderCartViewModel> orders = await this.orderService.GetAll()
                .Where(order => order.Status.Name == "Active"
                && order.IssuerId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .To<OrderCartViewModel>()
                .ToListAsync();

            return this.View(orders);
        }

        [HttpPost]
        [Route("/Order/{id}/Quantity/Reduce")]
        [Authorize]
        public async Task<IActionResult> Reduce(string id)
        {
            bool result = await this.orderService.ReduceQuantity(id);

            if (result)
            {
                return this.Ok();
            }
            else
            {
                return this.Forbid();
            }
        }

        [HttpPost]
        [Route("/Order/{id}/Quantity/Increase")]
        [Authorize]
        public async Task<IActionResult> Increase(string id)
        {
            bool result = await this.orderService.IncreaseQuantity(id);

            if (result)
            {
                return this.Ok();
            }
            else
            {
                return this.Forbid();
            }
        }

        [HttpPost]
        [Route("/Order/Cart/Complete")]
        [Authorize]
        public async Task<IActionResult> Complete()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            string receiptId = await this.receiptService.CreateReceipt(userId, 2);

            return this.Redirect($"/Receipt/Details/{receiptId}");
        }

        [HttpPost]
        [Route("/Order/{id}/Id/Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            bool result = await this.orderService.DeleteOrder(id);

            if (result)
            {
                return this.Ok();
            }
            else
            {
                return this.Forbid();
            }
        }
    }
}