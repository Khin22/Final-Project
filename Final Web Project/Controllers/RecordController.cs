using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services;
using Final_Web_Project.ViewModels.Record;
using Microsoft.AspNetCore.Mvc;
using Final_Web_Project.InputModels;
using Final_Web_Project.Services.ServiceModels;
using System.Security.Claims;

namespace Final_Web_Project.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordSerice recordSerice;
        private readonly IOrderService orderService;

        public RecordController(IRecordSerice recordSerice, IOrderService orderService)
        {
            this.recordSerice = recordSerice;
            this.orderService = orderService;
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string id)
        {
            RecordDetailsViewModel recordDetails = (await 
                this.recordSerice.GetById(id)).To<RecordDetailsViewModel>();

            return View(recordDetails);
        }

        [HttpPost(Name = "Order")]
        public async Task<IActionResult> Order(RecordOrderInputModel recordOrderInputModel)
        {
            OrderServiceModel orderServiceModel = recordOrderInputModel.To<OrderServiceModel>();

            orderServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.orderService.CreateOrderAsync(orderServiceModel);

            return this.Redirect("/");
        }
    }
}