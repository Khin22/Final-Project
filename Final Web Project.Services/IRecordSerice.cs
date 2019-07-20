using Final_Web_Project.InputModels;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Web_Project.Services
{
    public interface IRecordSerice
    {
        Task<bool> Create(RecordServiceModel recordServiceModel);

        IQueryable<RecordServiceModel> GetAllRecords();
    }
}
