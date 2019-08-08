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
    public class RecordService : IRecordSerice
    {
        private const string PriceAscendingCase = "price-lowest-to-highest";
        private const string PriceDescendingCase = "price-highest-to-lowest";
        private const string ProducingDateAscendingCase = "Producing-Date-oldest-to-latest";
        private const string ProducingDateDescendingCase = "Producing-Date-latest-to-oldest";

        private readonly FinalWebProjectDbContext finalWebProjectDbContext;

        public RecordService(FinalWebProjectDbContext finalWebProjectDbContext)
        {
            this.finalWebProjectDbContext = finalWebProjectDbContext;
        }

        private IQueryable<Record> GetAllRecordsByPriceAscending()
        {
            return this.finalWebProjectDbContext.Records.OrderBy(record => record.Price);
        }

        private IQueryable<Record> GetAllRecordsByPriceDescending()
        {
            return this.finalWebProjectDbContext.Records.OrderByDescending(record => record.Price);
        }

        private IQueryable<Record> GetAllRecordsByDateProducedAscending()
        {
            return this.finalWebProjectDbContext.Records.OrderBy(record => record.DateProduced);
        }

        private IQueryable<Record> GetAllRecordsByDateProducedDescending()
        {
            return this.finalWebProjectDbContext.Records.OrderByDescending(record => record.DateProduced);
        }

        public async Task<bool> Create(RecordServiceModel recordServiceModel)
        {
            Genre GenreFromDb =
                finalWebProjectDbContext.Genres
                .SingleOrDefault(productType => productType.Name == recordServiceModel.Genre.Name);

            Record record = AutoMapper.Mapper.Map<Record>(recordServiceModel);
            record.Genre = GenreFromDb;

            finalWebProjectDbContext.Records.Add(record);
            int result = await finalWebProjectDbContext.SaveChangesAsync();

            return result > 0;
        }
        public IQueryable<RecordServiceModel> GetAllRecords(string ordering = null)
        {
            switch (ordering)
            {
                case PriceAscendingCase: return this.GetAllRecordsByPriceAscending().To<RecordServiceModel>();
                case PriceDescendingCase: return this.GetAllRecordsByPriceDescending().To<RecordServiceModel>();
                case ProducingDateAscendingCase: return this.GetAllRecordsByDateProducedAscending().To<RecordServiceModel>();
                case ProducingDateDescendingCase: return this.GetAllRecordsByDateProducedDescending().To<RecordServiceModel>();
            }

            return this.finalWebProjectDbContext.Records.To<RecordServiceModel>();
        }

        public async Task<bool> CreateGenre(GenreServiceModel genreServiceModel)
        {
            Genre genre = new Genre
            {
                Name = genreServiceModel.Name
            };

            finalWebProjectDbContext.Genres.Add(genre);
            int result = await finalWebProjectDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteGenre(string name)
        {
            Genre genre = await this.finalWebProjectDbContext.Genres.SingleOrDefaultAsync(genres => genres.Name == name);
            var recordsByGenreId = await this.finalWebProjectDbContext.Records.Where(records => records.GenreId == genre.Id).ToListAsync();

            foreach (var item in recordsByGenreId)
            {
                recordsByGenreId.First(records => records.GenreId == genre.Id).GenreId = 3;
            }

            this.finalWebProjectDbContext.Genres.Remove(genre);
            int results = await this.finalWebProjectDbContext.SaveChangesAsync();
            return results > 0;
        }

        public IQueryable<GenreServiceModel> GetAllGenres()
        {
            return this.finalWebProjectDbContext.Genres.To<GenreServiceModel>();
        }

        public async Task<RecordServiceModel> GetById(string id)
        {
            return await this.finalWebProjectDbContext.Records
                .To<RecordServiceModel>()
                .SingleOrDefaultAsync(record => record.Id == id);
        }

        public async Task<bool> Edit(string id, RecordServiceModel recordServiceModel)
        {
            Genre GenreFromDb =
                finalWebProjectDbContext.Genres
                .SingleOrDefault(productType => productType.Name == recordServiceModel.Genre.Name);

            Record record = await this.finalWebProjectDbContext.Records.SingleOrDefaultAsync(records => records.Id == id);

            record.AlbumName = recordServiceModel.AlbumName;
            record.Artist = recordServiceModel.Artist;
            record.DateProduced = recordServiceModel.DateProduced;
            record.Price = recordServiceModel.Price;
            record.Picture = recordServiceModel.Picture;
            record.Quantity = recordServiceModel.Quantity;
            record.Description = recordServiceModel.Description;

            record.Genre = GenreFromDb;

            this.finalWebProjectDbContext.Records.Update(record);
            int result = await finalWebProjectDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            Record record = await this.finalWebProjectDbContext.Records.SingleOrDefaultAsync(records => records.Id == id);
            Order order = await this.finalWebProjectDbContext.Orders.SingleOrDefaultAsync(orders => orders.RecordId == record.Id);
            

            this.finalWebProjectDbContext.Orders.Remove(order);
            this.finalWebProjectDbContext.Records.Remove(record);

            int result = await this.finalWebProjectDbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
