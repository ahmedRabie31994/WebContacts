using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebContacts.DL.Models
{
    public class Message : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string MessageBody { get; set; }
        public string FilePath { get; set; }
        public int messageTypeId { get; set; }
        [ForeignKey("messageTypeId")]
        public virtual MessageType messageType { get; set; }

    }
}
