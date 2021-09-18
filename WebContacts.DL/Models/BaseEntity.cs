using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebContacts.DL.Models
{
    public  class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

    }
}
