using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Final_Web_Project.Services
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(OrderServiceModel orderServiceModel);
    }
}
