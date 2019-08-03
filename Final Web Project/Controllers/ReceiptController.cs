using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Final_Web_Project.Services;
using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using Final_Web_Project.ViewModels.Receipt.Details;
using Final_Web_Project.ViewModels.Receipt.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Project.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [HttpGet(Name = "Profile")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<ReceiptServiceModel> receiptsFromDb = await this.receiptService
                .GetAllByRecipientId(userId)
                .ToListAsync();

            List<ReceiptProfileViewModel> receiptsForCurrentUser = receiptsFromDb
                .Select(receipt => receipt.To<ReceiptProfileViewModel>()).ToList();

            return this.View(receiptsForCurrentUser);
        }

        [HttpGet(Name = "Details")]
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            ReceiptServiceModel receiptServiceModel = await this.receiptService.GetAll()
                .SingleOrDefaultAsync(receipt => receipt.Id == id);

            ReceiptDetailsViewModel receiptDetailsViewModel = receiptServiceModel.To<ReceiptDetailsViewModel>();

            return this.View(receiptDetailsViewModel);
        }
    }
}