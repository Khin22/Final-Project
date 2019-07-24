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
        IQueryable<GenreServiceModel> GetAllGenres();

        Task<bool> CreateGenre(GenreServiceModel GenreServiceModel);

        RecordServiceModel GetById(string id);

        Task<bool> Create(RecordServiceModel recordServiceModel);

        IQueryable<RecordServiceModel> GetAllRecords();
    }
}
