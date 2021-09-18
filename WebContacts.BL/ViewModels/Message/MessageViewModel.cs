using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebContacts.BL.ViewModels
{
    public  class MessageViewModel
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string MessageBody { get; set; }
        public string FilePath { get; set; }
        public int messageTypeId { get; set; }

        public string MessageTypeName { get; set; }
    }
}
