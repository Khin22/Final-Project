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
    public class ReceiptServiceTests
    {
        private IReceiptService receiptService;

        public ReceiptServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        private List<Receipt> GetDummyData()
        {
            return new List<Receipt>
            {
                new Receipt
                {
                    IssuedOn = DateTime.UtcNow
                },
                new Receipt
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

            this.receiptService = new ReceiptService(context, new OrderService(context));

            List<ReceiptServiceModel> actualResults = await this.receiptService.GetAll().ToListAsync();
            List<ReceiptServiceModel> expectedResults = context.Receipts.To<ReceiptServiceModel>().ToList();

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

            this.receiptService = new ReceiptService(context, new OrderService(context));

            List<ReceiptServiceModel> actualResults = await this.receiptService.GetAll().ToListAsync();

            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }
    }
}
