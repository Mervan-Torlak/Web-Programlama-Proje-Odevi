using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Web_Proje.Data;
using Web_Proje.Models;

namespace Web_Proje.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<MessagesController> _localizer;

        public MessagesController(ApplicationDbContext context, IStringLocalizer<MessagesController> localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        [HttpPost]
        public IActionResult Index(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(10) }
            );

            return RedirectToAction("Index");
        }

        // GET: Messages
        public async Task<IActionResult> Index(int id)
        {
            ViewData["uyari"] = _localizer["Yorum Yapmak İçin Giriş Yapınız!"];
            ViewData["sil"] = _localizer["Sil"];
            ViewData["yorumlar"] = _localizer["Yorumlar"];
            ViewData["yorumYaz"] = _localizer["Yorum Yaz"];
            ViewBag.id = id;
            return View(await _context.Messages.ToListAsync());
                    
        }

        // GET: Messages/Create
        [Authorize()]
        public IActionResult Create(int id)
        {
            ViewData["kullanici"] = _localizer["Kullanıcı"];
            ViewData["yorumlar"] = _localizer["Yorumlar"];
            ViewData["yorumYaz"] = _localizer["Yorum Yaz"];
            ViewData["yorum"] = _localizer["Yorum"];
            ViewData["yorumlaraDon"] = _localizer["Yorumlara Dön"];
            ViewData["olustur"] = _localizer["Oluştur"];
            ViewBag.id = id;
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("messageID,message,BookId,User")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(messages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(messages);
        }



        // GET: Messages/Delete/5
        [Authorize(Roles="admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["yorumlar"] = _localizer["Yorumlar"];
            ViewData["yorumYaz"] = _localizer["Yorum Yaz"];
            ViewData["yorum"] = _localizer["Yorum"];
            ViewData["yorumlaraDon"] = _localizer["Yorumlara Dön"];
            ViewData["olustur"] = _localizer["Oluştur"];
            ViewData["silUyari"] = _localizer["Silmek istediğinden emin misin?"];
            ViewData["sil"] = _localizer["Sil"];
            ViewData["kullanici"] = _localizer["Kullanıcı"];
            if (id == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages
                .FirstOrDefaultAsync(m => m.messageID == id);
            if (messages == null)
            {
                return NotFound();
            }

            return View(messages);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var messages = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(messages);
            await _context.SaveChangesAsync();
            return Redirect("~/Home/Index");
        }

        private bool MessagesExists(int id)
        {
            return _context.Messages.Any(e => e.messageID == id);
        }
    }
}
