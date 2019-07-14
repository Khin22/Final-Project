using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final_Web_Project.Data;
using Final_Web_Project.Domain;
using Final_Web_Project.InputModels;

namespace Final_Web_Project.Services
{
    public class RecordService : IRecordSerice
    {
        private readonly FinalWebProjectDbContext finalWebProjectDbContext;

        public RecordService(FinalWebProjectDbContext finalWebProjectDbContext)
        {
            this.finalWebProjectDbContext = finalWebProjectDbContext;
        }

        public async Task<bool> Create(RecordCreateInputModel recordCreateInputModel)
        {
            Record record = new Record
            {
                AlbumName = recordCreateInputModel.AlbumName,
                Artist = recordCreateInputModel.Artist,
                Price = recordCreateInputModel.Price,
                Quantity = recordCreateInputModel.Quantity
            };

            finalWebProjectDbContext.Records.Add(record);
            await finalWebProjectDbContext.SaveChangesAsync();

            return true;
        }
    }
}
