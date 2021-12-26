using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Models
{
    public class Messages
    {
        [Key]
        public int messageID { get; set; }
        public string message { get; set; }
        public int BookId { get; set; }
        public string User { get; set; }
    }
}
