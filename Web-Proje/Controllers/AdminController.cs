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
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<AdminController> _localizer;

        public AdminController(ApplicationDbContext context, IStringLocalizer<AdminController> localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            ViewData["yeniKitapOlustur"] = _localizer["Yeni Kitap Oluştur"];
            ViewData["kitapBasligi"] = _localizer["Kitap Başlığı"];
            ViewData["ilkBasimTarihi"] = _localizer["İlk Basım Tarihi"];
            ViewData["yazar"] = _localizer["Yazar"];
            ViewData["sayfaSayisi"] = _localizer["Sayfa Sayısı"];
            ViewData["konu"] = _localizer["Konu"];
            ViewData["resimLinki"] = _localizer["Resim linki"];
            ViewData["kategori"] = _localizer["Kategori"];
            ViewData["duzenle"] = _localizer["Düzenle"];
            ViewData["sil"] = _localizer["Sil"];
            ViewData["detaylar"] = _localizer["Detaylar"];
            return View(await _context.books.ToListAsync());
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

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["kitaplar"] = _localizer["Kitaplar"];
            ViewData["kitapBasligi"] = _localizer["Kitap Başlığı"];
            ViewData["ilkBasimTarihi"] = _localizer["İlk Basım Tarihi"];
            ViewData["yazar"] = _localizer["Yazar"];
            ViewData["sayfaSayisi"] = _localizer["Sayfa Sayısı"];
            ViewData["konu"] = _localizer["Konu"];
            ViewData["resimLinki"] = _localizer["Resim linki"];
            ViewData["kategori"] = _localizer["Kategori"];
            ViewData["duzenle"] = _localizer["Düzenle"];
            ViewData["detaylar"] = _localizer["Detaylar"];
            ViewData["listeyeDon"] = _localizer["Listeye Dön"];
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.books
                .FirstOrDefaultAsync(m => m.kitapID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
           
            ViewData["kitapBasligi"] = _localizer["Kitap Başlığı"];
            ViewData["ilkBasimTarihi"] = _localizer["İlk Basım Tarihi"];
            ViewData["yazar"] = _localizer["Yazar"];
            ViewData["sayfaSayisi"] = _localizer["Sayfa Sayısı"];
            ViewData["konu"] = _localizer["Konu"];
            ViewData["resimLinki"] = _localizer["Resim linki"];
            ViewData["kategori"] = _localizer["Kategori"];
            ViewData["listeyeDon"] = _localizer["Listeye Dön"];
            ViewData["olustur"] = _localizer["Oluştur"];
            ViewData["kitaplar"] = _localizer["Kitaplar"];
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("kitapID,kitapAdi,basimYili,yazar,sayfaSayisi,konu,link,kategori")] Books books)
        {
            if (ModelState.IsValid)
            {
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["kitapBasligi"] = _localizer["Kitap Başlığı"];
            ViewData["ilkBasimTarihi"] = _localizer["İlk Basım Tarihi"];
            ViewData["yazar"] = _localizer["Yazar"];
            ViewData["sayfaSayisi"] = _localizer["Sayfa Sayısı"];
            ViewData["konu"] = _localizer["Konu"];
            ViewData["resimLinki"] = _localizer["Resim linki"];
            ViewData["kategori"] = _localizer["Kategori"];
            ViewData["duzenle"] = _localizer["Düzenle"];

            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("kitapID,kitapAdi,basimYili,yazar,sayfaSayisi,konu,link,kategori")] Books books)
        {
            if (id != books.kitapID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.kitapID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["sil"] = _localizer["Sil"];
            ViewData["kitapBasligi"] = _localizer["Kitap Başlığı"];
            ViewData["ilkBasimTarihi"] = _localizer["İlk Basım Tarihi"];
            ViewData["yazar"] = _localizer["Yazar"];
            ViewData["sayfaSayisi"] = _localizer["Sayfa Sayısı"];
            ViewData["konu"] = _localizer["Konu"];
            ViewData["resimLinki"] = _localizer["Resim linki"];
            ViewData["kategori"] = _localizer["Kategori"];
            ViewData["kitaplar"] = _localizer["Kitaplar"];
            ViewData["listeyeDon"] = _localizer["Listeye Dön"];
            ViewData["uyari"] = _localizer["Silmek istedeğinden emin misin?"];
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.books
                .FirstOrDefaultAsync(m => m.kitapID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _context.books.FindAsync(id);
            _context.books.Remove(books);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
            return _context.books.Any(e => e.kitapID == id);
        }
    }
}
