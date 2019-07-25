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
    public class OrderService : IOrderService
    {
        private readonly FinalWebProjectDbContext finalWebProjectDbContext;

        public OrderService(FinalWebProjectDbContext finalWebProjectDbContext)
        {
            this.finalWebProjectDbContext = finalWebProjectDbContext;
        }

        public async Task<bool> CreateOrderAsync(OrderServiceModel orderServiceModel)
        {
            Order order = orderServiceModel.To<Order>();

            order.Status = await finalWebProjectDbContext.OrderStatuses
                .SingleOrDefaultAsync(orderStatus => orderStatus.Name == "Active");

            order.IssuedOn = DateTime.UtcNow;

            this.finalWebProjectDbContext.Orders.Add(order);
            int result = await this.finalWebProjectDbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<OrderServiceModel> GetAll()
        {
            return this.finalWebProjectDbContext.Orders.To<OrderServiceModel>();
        }
    }
}
