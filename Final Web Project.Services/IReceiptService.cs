using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Web_Project.Services
{
    public interface IReceiptService
    {
        Task<string> CreateReceipt(string recepientId);

        IQueryable<ReceiptServiceModel> GetAll();

        IQueryable<ReceiptServiceModel> GetAllByRecipientId(string recipientId);
    }
}
