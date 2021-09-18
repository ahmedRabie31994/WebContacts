using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebContacts.BL.Classes;
using WebContacts.BL.ViewModels;
using WebContacts.BL.ViewModels.Message;
using WebContacts.BL.ViewModels.MessageType;

namespace WebContacts.BL.Repositories.MessageTypeRepo
{
    public interface ImessageTypeRepository
    {
        Task<Response> Add(MessageTypeCriteria model);
        Task<Response> DeleteMessageType(int Id, int UserId);
        Task<MessageViewModel> GetMessageTypeById(int Id);
        IEnumerable<MessageTypeViewModel> GetAllMessageTypes(bool isActive);
    }
}
