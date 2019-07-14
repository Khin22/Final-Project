using Final_Web_Project.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Final_Web_Project.Services
{
    public interface IRecordSerice
    {
        Task<bool> Create(RecordCreateInputModel recordCreateInputModel);
    }
}
