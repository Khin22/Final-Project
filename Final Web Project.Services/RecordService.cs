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
            Record record = AutoMapper.Mapper.Map<Record>(recordServiceModel);

            finalWebProjectDbContext.Records.Add(record);
            await finalWebProjectDbContext.SaveChangesAsync();

            return true;
        }

        public IQueryable<RecordServiceModel> GetAllRecords()
        {
            return this.finalWebProjectDbContext.Records.To<RecordServiceModel>();
        }
    }
}
