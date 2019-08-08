using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Web_Project.Services
{
    public interface IDeliveryService
    {
        Task<bool> CreateDelivery(DeliveryDetailsServiceModel DeliveryDetailsServiceModel);

        IQueryable<DeliveryDetailsServiceModel> GetAll();

        IQueryable<DeliveryDetailsServiceModel> GetAllByRecipientId(string recipientId);
    }
}
