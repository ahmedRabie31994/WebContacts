using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebContacts.BL.ViewModels.Message
{
    public class MessageCritieria
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public bool Deleted { get; set; }
        [Required(ErrorMessage ="name  is Requiered")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage ="not valid Mail")]
        [Required(ErrorMessage = "name  is Requiered")]

        public string Email { get; set; }
        public string Mobile { get; set; }

       
        [Required(ErrorMessage = "MessageBody is Required")]
        [MinLength(5, ErrorMessage = "min legth is  10 char")]
        public string MessageBody { get; set; }
        public string FilePath { get; set; }
        public int messageTypeId { get; set; }

    }
}
