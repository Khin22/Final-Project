﻿using System;
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

        public async Task<bool> CompleteOrder(string orderId)
        {
            Order orderFromDb = await this.finalWebProjectDbContext.Orders
                .SingleOrDefaultAsync(order => order.Id == orderId);

            if (orderFromDb == null || orderFromDb.Status.Name != "Active")
            {
                throw new ArgumentException(nameof(orderFromDb));
            }

            orderFromDb.Status = await this.finalWebProjectDbContext.OrderStatuses
                .SingleOrDefaultAsync(orderStatus => orderStatus.Name == "Completed");

            this.finalWebProjectDbContext.Update(orderFromDb);
            int result = await this.finalWebProjectDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteOrder(string orderId)
        {
            Order orderFromDb = await this.finalWebProjectDbContext.Orders
                .SingleOrDefaultAsync(order => order.Id == orderId);

            this.finalWebProjectDbContext.Remove(orderFromDb);
            int result = await this.finalWebProjectDbContext.SaveChangesAsync();

            return result > 0;
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

        public async Task SetOrdersToReceipt(Receipt receipt)
        {
            List<Order> ordersFromDb = await this.finalWebProjectDbContext.Orders
                 .Where(order => order.IssuerId == receipt.RecipientId && order.Status.Name == "Active").ToListAsync();

            receipt.Orders = ordersFromDb;
        }


        public async Task<bool> IncreaseQuantity(string orderId)
        {
            Order orderFromDb = await this.finalWebProjectDbContext.Orders
                .SingleOrDefaultAsync(order => order.Id == orderId);

            orderFromDb.Quantity++;

            this.finalWebProjectDbContext.Update(orderFromDb);
            int result = await this.finalWebProjectDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ReduceQuantity(string orderId)
        {
            Order orderFromDb = await this.finalWebProjectDbContext.Orders
                .SingleOrDefaultAsync(order => order.Id == orderId);

            if (orderFromDb.Quantity == 1)
            {
                return false;
            }

            orderFromDb.Quantity--;

            this.finalWebProjectDbContext.Update(orderFromDb);
            int result = await this.finalWebProjectDbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
