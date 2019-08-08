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
    public class DeliveryService : IDeliveryService
    {
        private readonly FinalWebProjectDbContext context;


        public DeliveryService(FinalWebProjectDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateDelivery(DeliveryDetailsServiceModel DeliveryDetailsServiceModel)
        {
            DeliveryDetails deliveryDetails = AutoMapper.Mapper.Map<DeliveryDetails>(DeliveryDetailsServiceModel);
            deliveryDetails.Id = null;

            Receipt receipt = await this.context.Receipts.SingleOrDefaultAsync(receipts => receipts.Id == deliveryDetails.ReceiptId);

            deliveryDetails.IssuedOn = DateTime.UtcNow;
            deliveryDetails.RecipientId = receipt.RecipientId;
            receipt.ReceiptStatusId = 1;

            context.DeliveryDetails.Add(deliveryDetails);
            int result = await context.SaveChangesAsync();


            return result > 0;
        }

        public IQueryable<DeliveryDetailsServiceModel> GetAllByRecipientId(string recipientId)
        {
            return this.context.DeliveryDetails.Where(receipt => receipt.RecipientId == recipientId).To<DeliveryDetailsServiceModel>();
        }

        public IQueryable<DeliveryDetailsServiceModel> GetAll()
        {
            return this.context.DeliveryDetails.To<DeliveryDetailsServiceModel>();
        }
    }
}
