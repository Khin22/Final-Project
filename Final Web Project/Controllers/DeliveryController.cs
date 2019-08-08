using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Final_Web_Project.Services.Mapping;
using System.Threading.Tasks;
using Final_Web_Project.Services;
using Final_Web_Project.Services.ServiceModels;
using Final_Web_Project.ViewModels.Delivery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Web_Project.InputModels;

namespace Final_Web_Project.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            this.deliveryService = deliveryService;
        }
        [HttpGet(Name = "Profile")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<DeliveryDetailsServiceModel> deliveryFromDb = await this.deliveryService
                .GetAllByRecipientId(userId)
                .ToListAsync();

            List<DeliveryDetailsViewModel> deliveriesForCurrentUser = deliveryFromDb
                .Select(receipt => receipt.To<DeliveryDetailsViewModel>()).ToList();

            return this.View(deliveriesForCurrentUser);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Deliver(string receiptId)
        {
            return this.View(receiptId);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Deliver(DeliveryDetailsCreateInputModel DeliveryDetailsCreateInputModel)
        {
            DeliveryDetailsCreateInputModel.ReceiptId = DeliveryDetailsCreateInputModel.Id;
            DeliveryDetailsServiceModel deliveryCreate = AutoMapper.Mapper.Map<DeliveryDetailsServiceModel>(DeliveryDetailsCreateInputModel);

            await this.deliveryService.CreateDelivery(deliveryCreate);

            return this.Redirect("/Delivery/Profile");
        }

        [HttpGet(Name = "Details")]
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            DeliveryDetailsServiceModel deliveryDetailsServiceModel = await this.deliveryService.GetAll()
                .SingleOrDefaultAsync(receipt => receipt.Id == id);

            DeliveryDetailsViewModel deliverytDetailsViewModel = deliveryDetailsServiceModel.To<DeliveryDetailsViewModel>();

            return this.View(deliverytDetailsViewModel);
        }
    }
}