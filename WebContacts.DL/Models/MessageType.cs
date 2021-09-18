using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebContacts.DL.Models
{
    public class MessageType:BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
