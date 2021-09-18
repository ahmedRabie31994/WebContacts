using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebContacts.BL.ViewModels.MessageType
{
    public class MessageTypeCriteria
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
