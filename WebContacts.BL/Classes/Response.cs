using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebContacts.BL.Classes
{
    public class Response
    {
        public bool Result { get; set; }
        public string ArabicMesage { get; set; }
        public string EnglishMessage { get; set; }
        public int statusCode { get; set; }
        public object Obj { get; set; }
    }
}
