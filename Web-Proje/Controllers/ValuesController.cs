using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Data;
using Web_Proje.Models;

namespace Web_Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public ValuesController(ApplicationDbContext context)
        {
            _context = context;//verileri bağlar

        }
        // GET: api/<ValuesController>
        //api/controllerde root atar
        [HttpGet]
        public IEnumerable<Books> Get()
        {
            return _context.books.ToList();//tüm kitapları sıralar
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Books Get(int id)
        {
            return _context.books.FirstOrDefault(c => c.kitapID == id);//kitapları yazdığımız ID ye göre sıralar
        }
    }
}
