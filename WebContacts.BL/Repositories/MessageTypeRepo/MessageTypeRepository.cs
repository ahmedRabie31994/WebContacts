using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebContacts.BL.Classes;
using WebContacts.BL.Repositories.MessageRepo;
using WebContacts.BL.ViewModels;
using WebContacts.BL.ViewModels.Message;
using WebContacts.BL.ViewModels.MessageType;
using WebContacts.DL.Context;
using WebContacts.DL.GenericRepository;
using WebContacts.DL.Models;

namespace WebContacts.BL.Repositories.MessageTypeRepo
{
    public class MessageTypeRepository : GenericRepository<MessageType>, ImessageTypeRepository
    {
        public MessageTypeRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        { }

        public async Task<Response> Add(MessageTypeCriteria model)
        {
            Response result;
            if (model != null)
            {
                MessageType messageType = new MessageType()
                {
                    Id = model.Id,
                    Name = model.Name,
                    CreationDate = DateTime.Now,
                    Deleted = false,
                    IsActive = true,
                    UpdatedDate = null
                };
                await AddAsync(messageType);
                await SaveTransaction();
                result = new Response
                {
                    Result = true,
                    EnglishMessage = $"message Type  with id = {model.Id} added successfully",
                    ArabicMesage = $"تمت الاضافه بنجاح",
                    Obj = messageType,
                    statusCode = 200
                };
            }
            else
            {
                result = new Response
                {
                    Result = false,
                    EnglishMessage = $"message with id = {model.Id} added successfully",
                    ArabicMesage = $"تمت الاضافه بنجاح",
                    Obj = null,
                    statusCode = 200
                };
            }
            return result;
        }



        public Task<Response> DeleteMessageType(int Id, int UserId)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<MessageTypeViewModel> GetAllMessageTypes(bool isActive)
        {
          var query =    Get(item => !item.Deleted).Select(item => new MessageTypeViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                CreationDate =item.CreationDate,
                Deleted = item.Deleted,
                IsActive = item.IsActive,
                UpdatedDate = item.UpdatedDate


            }).ToList();
            return query;
        }



        public Task<MessageViewModel> GetMessageTypeById(int Id)
        {
            throw new NotImplementedException();
        }



        public Task<Response> Update(int Id, MessageTypeCriteria model)
        {
            throw new NotImplementedException();
        }


    }
}
