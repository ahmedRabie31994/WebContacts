using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebContacts.BL.Classes;
using WebContacts.BL.ViewModels;
using WebContacts.BL.ViewModels.Message;
using WebContacts.BL.ViewModels.MessageType;

namespace WebContacts.BL.Repositories.MessageRepo
{
    public interface IMessageRepository
    {
        Task<Response> Add(MessageCritieria model);
        Task<Response> Update(int Id, MessageCritieria model);
        Task<MessageViewModel> GetMessageById(int Id);
        IEnumerable<MessageTypeViewModel> GetAllMessages(bool isActive);
        Task<Response> DeleteMessage(int Id, int UserId);
    }
}
