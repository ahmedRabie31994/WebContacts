using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebContacts.BL.Classes;
using WebContacts.BL.ViewModels;
using WebContacts.BL.ViewModels.Message;
using WebContacts.BL.ViewModels.MessageType;
using WebContacts.DL.Context;
using WebContacts.DL.GenericRepository;
using WebContacts.DL.Models;

namespace WebContacts.BL.Repositories.MessageRepo
{
    public  class MessageRepository :  GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        { }

        public async Task<Response> Add(MessageCritieria model)
        {
            try
            {


                Response result;
                if (model != null)
                {
                    Message messageType = new Message()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        CreationDate = DateTime.Now,
                        Deleted = false,
                        Email = model.Email,
                        FilePath = model.FilePath,
                        MessageBody = model.MessageBody,
                        Mobile = model.Mobile,
                        UpdatedDate = null,
                        messageTypeId = model.messageTypeId

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
            catch(Exception ex )
            {
                return new Response
                {
                    Result = false,
                    EnglishMessage = "Error Occured" + ex.Message,
                    ArabicMesage = "حدث خطأ ما " + ex.Message,
                    Obj = null,
                    statusCode = 400
                };
            }
        }

        public Task<Response> DeleteMessage(int Id, int UserId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageViewModel> GetAllMessages()
        {
            var query = Get(item => !item.Deleted).Select(item => new MessageViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                CreationDate = DateTime.Now,
                Deleted = false,
                Email = item.Email,
                FilePath = item.FilePath,
                MessageBody = item.MessageBody,
                Mobile = item.Mobile,
                UpdatedDate = item.UpdatedDate


            }).ToList();
            return query;
        }

        public IEnumerable<MessageTypeViewModel> GetAllMessages(bool isActive)
        {
            throw new NotImplementedException();
        }

        public Task<MessageViewModel> GetMessageById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(int Id, MessageCritieria model)
        {
            throw new NotImplementedException();
        }


    }
}
