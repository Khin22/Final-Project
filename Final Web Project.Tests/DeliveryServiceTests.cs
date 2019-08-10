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
    public class DeliveryServiceTests
    {
        private IDeliveryService deliveryService;

        public DeliveryServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        private List<DeliveryDetails> GetDummyData()
        {
            return new List<DeliveryDetails>
            {
                new DeliveryDetails
                {
                    IssuedOn = DateTime.UtcNow
                },
                new DeliveryDetails
                {
                    IssuedOn = DateTime.UtcNow
                }
            };
        }

        private async Task SeedData(FinalWebProjectDbContext context)
        {
            context.AddRange(GetDummyData());
            await context.SaveChangesAsync();
        }
        [Fact]
        public async Task GetAll_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "ReceiptService GetAll() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);

            this.deliveryService = new DeliveryService(context);

            List<DeliveryDetailsServiceModel> actualResults = await this.deliveryService.GetAll().ToListAsync();
            List<DeliveryDetailsServiceModel> expectedResults = context.DeliveryDetails.To<DeliveryDetailsServiceModel>().ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.IssuedOn == actualEntry.IssuedOn, errorMessagePrefix + " " + "Issued On is not returned properly.");
            }
        }
        [Fact]
        public async Task GetAll_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "ReceiptService GetAll() method does not work properly.";

            var context = ContextFactory.Initializer();

            this.deliveryService = new DeliveryService(context);

            List<DeliveryDetailsServiceModel> actualResults = await this.deliveryService.GetAll().ToListAsync();

            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }
    }
}
