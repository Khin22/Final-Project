using System;
using Final_Web_Project.Services.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Final_Web_Project.Services;
using Final_Web_Project.ViewModels.Order.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Route("/Order/Cart/Complete")]
        public async Task<IActionResult> Complete()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.receiptService.CreateReceipt(userId);

            return this.Redirect("/");
        }
    }
}