using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Web_Project.Services
{
    public interface IRecordService
    {
        IQueryable<GenreServiceModel> GetAllGenres();

        Task<bool> CreateGenre(GenreServiceModel genreServiceModel);

        Task<bool> DeleteGenre(string name);

        Task<RecordServiceModel> GetById(string id);

        Task<bool> Create(RecordServiceModel recordServiceModel);

        Task<bool> Edit(string id, RecordServiceModel recordServiceModel);

        Task<bool> Delete(string id);

        IQueryable<RecordServiceModel> GetAllRecords(string ordering = null);
    }
}
