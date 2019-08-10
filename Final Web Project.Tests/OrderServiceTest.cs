using Final_Web_Project.Data;
using Final_Web_Project.Domain;
using Final_Web_Project.Services;
using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using Final_Web_Project.Tests.Factory;
using Final_Web_Project.Tests.Factory.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Final_Web_Project.Tests
{
    public class OrderServiceTest
    {
        private IOrderService orderService;

        public OrderServiceTest()
        {
            MapperInitializer.InitializeMapper();
        }

        private List<Order> GetDummyData()
        {
            return new List<Order>
            {
                new Order
                {
                    IssuedOn = DateTime.UtcNow,
                    Quantity = 1,
                    Status = new OrderStatus
                    {
                        Name = "Active"
                    }
                },
                new Order
                {
                    IssuedOn = DateTime.UtcNow,
                    Quantity = 2,
                    Status = new OrderStatus
                    {
                        Name = "Completed"
                    }
                },
                new Order
                {
                    IssuedOn = DateTime.UtcNow,
                    Quantity = 3,
                    Status = new OrderStatus
                    {
                        Name = "Invalid Status"
                    }
                }
            };
        }

        private async Task SeedData(FinalWebProjectDbContext context)
        {
            context.AddRange(GetDummyData());
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task CreateOrder_WithCorrectData_ShouldSuccessfullyCreateOrder()
        {
            string errorMessagePrefix = "OrderService Create() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.orderService = new OrderService(context);

            OrderServiceModel testReceipt = new OrderServiceModel();

            bool actualResult = await this.orderService.CreateOrderAsync(testReceipt);
            Assert.True(actualResult, errorMessagePrefix);
        }
        [Fact]
        public async Task GetAll_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "OrderService GetAll() method does not work properly.";

            var context = ContextFactory.Initializer();
            this.orderService = new OrderService(context);

            List<OrderServiceModel> actualResults = await this.orderService.GetAll().ToListAsync();

            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }
        [Fact]
        public async Task GetAll_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "OrderService GetAll() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.orderService = new OrderService(context);

            List<OrderServiceModel> actualResults = await this.orderService.GetAll()
                .ToListAsync();
            List<OrderServiceModel> expectedResults = context.Orders
                .To<OrderServiceModel>().ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Quantity == actualEntry.Quantity, errorMessagePrefix + " " + "Quantity is not returned properly.");
                Assert.True(expectedEntry.IssuedOn == actualEntry.IssuedOn, errorMessagePrefix + " " + "Issued On is not returned properly.");
                Assert.True(expectedEntry.Status.Name == actualEntry.Status.Name, errorMessagePrefix + " " + "Status is not returned properly.");
            }
        }
        [Fact]
        public async Task CompleteOrder_WithExistentId_ShouldSuccessfullyCompleteOrder()
        {
            string errorMessagePrefix = "OrderService CompleteOrder() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.orderService = new OrderService(context);

            string testId = context.Orders.First().Id;
            await this.orderService.CompleteOrder(testId);
            Order testOrder = context.Orders.First();

            Assert.True(testOrder.Status.Name == "Completed", errorMessagePrefix);
        }
        [Fact]
        public async Task CompleteOrder_WithNonExistentId_ShouldThrowArgumentException()
        {
            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.orderService = new OrderService(context);

            string testId = "Non_Existent";

            await Assert.ThrowsAsync<ArgumentException>(() => this.orderService.CompleteOrder(testId));
        }
        [Fact]
        public async Task CompleteOrder_WithInactiveStatus_ShouldThrowArgumentException()
        {
            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.orderService = new OrderService(context);

            string testId = context.Orders.FirstOrDefault(order => order.Status.Name != "Active").Id;

            await Assert.ThrowsAsync<ArgumentException>(() => this.orderService.CompleteOrder(testId));
        }

        [Fact]
        public async Task IncreaseQuantity_WithExistentId_ShouldSuccessfullyIncreaseQuantity()
        {
            string errorMessagePrefix = "OrderService IncreaseQuantity() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.orderService = new OrderService(context);

            OrderServiceModel testOrder = context.Orders.First().To<OrderServiceModel>();
            await this.orderService.IncreaseQuantity(testOrder.Id);

            int expectedQuantity = testOrder.Quantity + 1;
            int actualQuantity = context.Orders.First().Quantity;

            Assert.True(expectedQuantity == actualQuantity, errorMessagePrefix);
        }
        [Fact]
        public async Task ReduceQuantity_WithExistentId_ShouldSuccessfullyReduceQuantity()
        {
            string errorMessagePrefix = "OrderService ReduceQuantity() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.orderService = new OrderService(context);

            OrderServiceModel testOrder = context.Orders.First().To<OrderServiceModel>();
            await this.orderService.ReduceQuantity(testOrder.Id);

            int actualQuantity = 0;
            int expectedQuantity = 0;

            if (testOrder.Quantity >= 1)
            {
                expectedQuantity = testOrder.Quantity - 1;
            }
            else
            {
                actualQuantity = context.Orders.First().Quantity;
            }

            Assert.True(expectedQuantity == actualQuantity, errorMessagePrefix);
        }
        [Fact]
        public async Task SetOrdersToReceipt_WithCorrectData_ShouldSuccessfullySetOrdersToReceipt()
        {
            string errorMessagePrefix = "OrderService SetOrdersToReceipt() method does not work properly.";

            var context = ContextFactory.Initializer();

            #region Dummy Data
            context.Orders.Add(new Order
            {
                IssuerId = "1",
                Status = new OrderStatus
                {
                    Name = "Active"
                }
            });
            context.Receipts.Add(new Receipt
            {
                RecipientId = "1"
            });
            await context.SaveChangesAsync();
            #endregion

            this.orderService = new OrderService(context);

            Receipt testReceipt = context.Receipts.First();
            await this.orderService.SetOrdersToReceipt(testReceipt);

            int expectedCountOfOrders = 1;
            int actualCountOfOrders = context.Receipts.First().Orders.Count;

            Assert.True(expectedCountOfOrders == actualCountOfOrders, errorMessagePrefix);
        }
    }
}
