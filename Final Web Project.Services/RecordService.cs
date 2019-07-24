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
        private readonly FinalWebProjectDbContext finalWebProjectDbContext;

        public RecordService(FinalWebProjectDbContext finalWebProjectDbContext)
        {
            this.finalWebProjectDbContext = finalWebProjectDbContext;
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
        public IQueryable<RecordServiceModel> GetAllRecords()
        {
            return this.finalWebProjectDbContext.Records.To<RecordServiceModel>();
        }

        public async Task<bool> CreateGenre(GenreServiceModel GenreServiceModel)
        {
            Genre genre = new Genre
            {
                Name = GenreServiceModel.Name
            };

            finalWebProjectDbContext.Genres.Add(genre);
            int result = await finalWebProjectDbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<GenreServiceModel> GetAllGenres()
        {
            return this.finalWebProjectDbContext.Genres.To<GenreServiceModel>();
        }

    }
}
