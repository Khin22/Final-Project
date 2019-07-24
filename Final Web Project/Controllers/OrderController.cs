using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Web_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        //[HttpGet("Cart")]
        //[Route("/Order/Cart")]
        //public async Task<IActionResult> Cart()
        //{
        //    List<OrderCartViewModel> orders = await this.orderService.GetAll()
        //        .Where(order => order.Status.Name == "Active"
        //        && order.IssuerId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
        //        .To<OrderCartViewModel>()
        //        .ToListAsync();

        //    return this.View(orders);
        //}

        [HttpPost]
        [Route("/Order/Cart/Complete")]
        public IActionResult Complete()
        {
            return this.View();
        }
    }
}