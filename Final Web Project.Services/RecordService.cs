using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Web_Project.Data;
using Final_Web_Project.Domain;
using Final_Web_Project.InputModels;
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
            Record record = new Record
            {
                AlbumName = recordServiceModel.AlbumName,
                Artist = recordServiceModel.Artist,
                Price = recordServiceModel.Price,
                Quantity = recordServiceModel.Quantity,
                Picture = recordServiceModel.Picture
            };

            finalWebProjectDbContext.Records.Add(record);
            await finalWebProjectDbContext.SaveChangesAsync();

            return true;
        }

        public IQueryable<RecordServiceModel> GetAllRecords()
        {
            return this.finalWebProjectDbContext.Records.Select(record => new RecordServiceModel
            {
                AlbumName = record.AlbumName,
                Artist = record.Artist,
                Price = record.Price,
                Picture = record.Picture,
                Quantity = record.Quantity
            });
        }
    }
}
