using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Models
{
    public class Books
    {
        [Key]
        public int kitapID { get; set; }
        public string kitapAdi { get; set; }
        public int basimYili { get; set; }
        public string yazar { get; set; }
        public int sayfaSayisi { get; set; }
        public string konu { get; set; }
        public string link { get; set; }
        public string kategori { get; set; }
    }
}
