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
using System.Threading.Tasks;
using Xunit;

namespace Final_Web_Project.Tests
{
    public class RecordServiceTest

    {
        public RecordServiceTest()
        {
            MapperInitializer.InitializeMapper();
        }

        private IRecordService recordService;

        private IOrderService orderService;

        private List<Order> GetDummyDataOrder()
        {
            return new List<Order>
            {
                new Order
                {
                    IssuedOn = DateTime.UtcNow.AddDays(-10),
                    Quantity = 5,
                    Status = new OrderStatus
                    {
                        Name = "Active"
                    }
                },
                new Order
                {
                    IssuedOn = DateTime.UtcNow.AddDays(-15),
                    Quantity = 10,
                    Status = new OrderStatus
                    {
                        Name = "Completed"
                    }
                },
                new Order
                {
                    IssuedOn = DateTime.UtcNow.AddDays(-15),
                    Quantity = 1,
                    Status = new OrderStatus
                    {
                        Name = "Invalid Status"
                    }
                }
            };
        }

        private async Task SeedDataOrder(FinalWebProjectDbContext context)
        {
            context.AddRange(GetDummyDataOrder());
            await context.SaveChangesAsync();
        }

        private List<Domain.Record> GetDummyData()
        {
            return new List<Domain.Record>()
            {
                new Domain.Record
                {
                    AlbumName = "Master Of Puppets",
                    Artist = "Metallica",
                    DateProduced = DateTime.UtcNow.AddDays(-20),
                    Description = "epic",
                    Price = 214M,
                    Picture = "this/is/the/cover/of/the/album",
                    Quantity = 1,
                    Genre = new Domain.Genre
                    {
                        Name = "Thrash"
                    }
                },

                //new Domain.Record
                //{
                //    AlbumName = "Ride The Lightinng",
                //    Artist = "Metallica",
                //    DateProduced = DateTime.UtcNow.AddDays(-40),
                //    Description = "epic as well",
                //    Price = 2142M,
                //    Picture = "this/is/the/cover/of/the/album/butDifferent",
                //    Quantity = 11,
                //    Genre = new Domain.Genre
                //    {
                //        Name = "Thrash"
                //    }
                //}
            };
        }

        private async Task SeedData(FinalWebProjectDbContext context)
        {
            context.AddRange(GetDummyData());
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetAllGenres_ShouldReturnAllGenres()
        {
            var context = ContextFactory.Initializer();

            string errorMessage = "RecordService GetAllRecords() method does not work properly.";

            await SeedData(context);
            this.recordService = new RecordService(context);

            List<RecordServiceModel> actualResults = await this.recordService.GetAllRecords().ToListAsync();
            List<RecordServiceModel> expectedResults = GetDummyData().To<RecordServiceModel>().ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.AlbumName == actualEntry.AlbumName, errorMessage + " " + "AlbumName is not returned properly.");
                Assert.True(expectedEntry.Artist == actualEntry.Artist, errorMessage + " " + "Artist is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessage + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.Picture == actualEntry.Picture, errorMessage + " " + "Picture is not returned properly.");
                Assert.True(expectedEntry.Genre.Name == actualEntry.Genre.Name, errorMessage + " " + "Genre is not returned properly.");
            }
            this.recordService = new RecordService(context);
        }
        [Fact]
        public async Task GetAllGenres_Empty_ShouldReturnAllGenres()
        {
            var context = ContextFactory.Initializer();

            string errorMessage = "RecordService GerAllRecords() method does not work properly.";

            this.recordService = new RecordService(context);

            List<RecordServiceModel> actualResults = await this.recordService.GetAllRecords().ToListAsync();

            Assert.True(actualResults.Count == 0, errorMessage);
        }
        [Fact]
        public async Task GetById_Existing_ShouldReturnCorrectResult()
        {
            string errorMessage = "RecordService GetById() method does not work properly.";

            var context = ContextFactory.Initializer();

            await SeedData(context);
            this.recordService = new RecordService(context);

            RecordServiceModel expectedResults = context.Records.First().To<RecordServiceModel>();
            RecordServiceModel actualResult = await this.recordService.GetById(expectedResults.Id);

            Assert.True(expectedResults.Id == actualResult.Id, errorMessage + " " + "Id is not returned properly.");
            Assert.True(expectedResults.AlbumName == actualResult.AlbumName, errorMessage + " " + "AlbumName is not returned properly.");
            Assert.True(expectedResults.Price == actualResult.Price, errorMessage + " " + "Price is not returned properly.");
            Assert.True(expectedResults.Picture == actualResult.Picture, errorMessage + " " + "Picture is not returned properly.");
            Assert.True(expectedResults.Genre.Name == actualResult.Genre.Name, errorMessage + " " + "Genre is not returned properly.");
        }
        [Fact]
        public async Task GetById_WithNonExistentId_ShouldReturnNull()
        {
            string errorMessage = "RecordService GetById() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.recordService = new RecordService(context);

            RecordServiceModel actualData = await this.recordService.GetById("fakeIDd");

            Assert.True(actualData == null, errorMessage);
        }
        [Fact]
        public async Task Create_ShouldSuccessfullyCreateRecord()
        {
            string errorMessage = "RecordService Create() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.recordService = new RecordService(context);

            RecordServiceModel testrecord = new RecordServiceModel
            {
                AlbumName = "Indestructable",
                Artist = "Disturbed",
                Price = 45,
                DateProduced = DateTime.UtcNow,
                Picture = "fake/pic",
                Genre = new GenreServiceModel
                {
                    Name = "Metal"
                },
                Description = "Inside the fire"
            };

            bool actualResult = await this.recordService.Create(testrecord);
            Assert.True(actualResult, errorMessage);
        }
        [Fact]
        public async Task CreateGenre_ShouldSuccessfullyCreateГенре()
        {
            string errorMessage = "RecordService CreateGenre() method does not work properly.";

            var context = ContextFactory.Initializer();
            this.recordService = new RecordService(context);

            GenreServiceModel testGenre = new GenreServiceModel
            {
                Name = "Doom"
            };

            bool actualResult = await this.recordService.CreateGenre(testGenre);
            Assert.True(actualResult, errorMessage);
        }
        [Fact]
        public async Task Edit_ShouldPassSuccessfully()
        {
            string errorMessage = "ProductService Edit() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.recordService = new RecordService(context);

            RecordServiceModel expectedResult = context.Records.First().To<RecordServiceModel>();

            bool actualResult = await this.recordService.Edit(expectedResult.Id, expectedResult);

            Assert.True(actualResult, errorMessage);
        }
        [Fact]
        public async Task Edit_WithCorrectData_ShouldEditProductCorrectly()
        {
            string errorMessagePrefix = "RecordService Edit() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.recordService = new RecordService(context);

            RecordServiceModel expectedResult = context.Records.First().To<RecordServiceModel>();

            expectedResult.AlbumName = "Editted_Name";
            expectedResult.Price = 0.01M;
            expectedResult.DateProduced = DateTime.UtcNow;
            expectedResult.Picture = "Editted_Picture";
            expectedResult.Genre = context.Genres.Last().To<GenreServiceModel>();

            await this.recordService.Edit(expectedResult.Id, expectedResult);

            RecordServiceModel actualResult = context.Records.First().To<RecordServiceModel>();

            Assert.True(actualResult.AlbumName == expectedResult.AlbumName, errorMessagePrefix + " " + "AlbumName not editted properly.");
            Assert.True(actualResult.Price == expectedResult.Price, errorMessagePrefix + " " + "Price not editted properly.");
            Assert.True(actualResult.DateProduced == expectedResult.DateProduced, errorMessagePrefix + " " + "Manufactured On not editted properly.");
            Assert.True(actualResult.Picture == expectedResult.Picture, errorMessagePrefix + " " + "Picture not editted properly.");
            Assert.True(actualResult.Genre.Name == expectedResult.Genre.Name, errorMessagePrefix + " " + "Genre not editted properly.");

        }
        [Fact]
        public async Task Delete_ShouldPassSuccessfully()
        {
            string errorMessagePrefix = "RecordService Delete() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            this.recordService = new RecordService(context);

            string testId = context.Records.First().To<RecordServiceModel>().Id;

            bool actualData = await this.recordService.Delete(testId);

            Assert.True(actualData, errorMessagePrefix);
        }

        [Fact]
        public async Task Delete_ShouldDeleteSuccessfully()
        {
            string errorMessagePrefix = "RecordService Delete() method does not work properly.";

            var context = ContextFactory.Initializer();
            await SeedData(context);
            await SeedDataOrder(context);
            this.recordService = new RecordService(context);
            this.orderService = new OrderService(context);

            string testId = context.Records.First().To<RecordServiceModel>().Id;
            string testOrderRecordId = context.Orders.First().To<OrderServiceModel>().RecordId;
            if (testOrderRecordId == testId)
            {
                await this.recordService.Delete(testOrderRecordId);
            }

            await this.recordService.Delete(testId);

            int expectedCount = 0;
            int actualCount = context.Records.Count();

            Assert.True(expectedCount == actualCount, errorMessagePrefix);
        }
    }
}
