using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Web_Project.Data;
using Final_Web_Project.Domain;
using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Project.Services
{
    public class ReceiptService : IReceiptService
    {

        private readonly FinalWebProjectDbContext context;

        private readonly IOrderService orderService;

        public ReceiptService(FinalWebProjectDbContext context, IOrderService orderService)
        {
            this.context = context;
            this.orderService = orderService;
        }

        public async Task<string> CreateReceipt(string recepientId, int receiptStatusId)
        {
            Receipt receipt = new Receipt
            {
                IssuedOn = DateTime.UtcNow,
                RecipientId = recepientId,
                ReceiptStatusId = receiptStatusId
            };

            ReceiptStatus receiptStatus = new ReceiptStatus {Id = receipt.ReceiptStatusId};

            await this.orderService.SetOrdersToReceipt(receipt);

            foreach (var order in receipt.Orders)
            {
                await this.orderService.CompleteOrder(order.Id);
            }

            this.context.Receipts.Add(receipt);
            int result = await this.context.SaveChangesAsync();


            return receipt.Id;
        }

        public IQueryable<ReceiptServiceModel> GetAll()
        {
            return this.context.Receipts.To<ReceiptServiceModel>();
        }

        public IQueryable<ReceiptServiceModel> GetAllByRecipientId(string recipientId)
        {
            return this.context.Receipts.Where(receipt => receipt.RecipientId == recipientId).To<ReceiptServiceModel>();
        }
    }
}
