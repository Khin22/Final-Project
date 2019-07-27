using Final_Web_Project.Domain;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Web_Project.Services
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(OrderServiceModel orderServiceModel);

        IQueryable<OrderServiceModel> GetAll();

        Task SetOrdersToReceipt(Receipt receipt);

        Task<bool> CompleteOrder(string orderId);
    }
}
