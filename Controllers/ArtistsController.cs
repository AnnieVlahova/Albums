using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Albums.Data;
using Albums.Models;
using Albums.Data.Enums;

namespace Albums.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly AppDbContext _context;

        public ArtistsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
              return _context.Artists != null ? 
                          View(await _context.Artists.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Artists'  is null.");
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PictureURL,FullName,Bio,BirthDate")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                if (artist.BirthDate != null)
                {
                    artist.AstroSign = astroSign((DateTime)artist.BirthDate);
                }
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PictureURL,FullName,Bio,BirthDate")] Artist artist)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(artist.BirthDate != null)
                    {
                        artist.AstroSign = astroSign((DateTime)artist.BirthDate);
                    }
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.Id))
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
            return View(artist);
        }

        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artists == null)
            {
                return Problem("Entity set 'AppDbContext.Artists'  is null.");
            }
            var artist = await _context.Artists.FindAsync(id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
          return (_context.Artists?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private AstroSign astroSign(DateTime bd)
        {
            int month = Convert.ToInt32(bd.Month);
            int day = Convert.ToInt32(bd.Day);
            AstroSign sign;

            switch (month)
            {
                case 1:
                    if (day >= 20) sign = AstroSign.Aquarius;
                    else sign = AstroSign.Capricorn;
                    break;
                case 2:
                    if (day >= 19) sign = AstroSign.Pisces;
                    else sign = AstroSign.Aquarius;
                    break;
                case 3:
                    if (day >= 21) sign = AstroSign.Aries;
                    else sign = AstroSign.Pisces;
                    break;
                case 4:
                    if (day >= 20) sign = AstroSign.Taurus;
                    else sign = AstroSign.Aries;
                    break;
                case 5:
                    if (day >= 21) sign = AstroSign.Gemini;
                    else sign = AstroSign.Taurus;
                    break;
                case 6:
                    if (day >= 21) sign = AstroSign.Cancer;
                    else sign = AstroSign.Gemini;
                    break;
                case 7:
                    if (day >= 23) sign = AstroSign.Leo;
                    else sign = AstroSign.Cancer;
                    break;
                case 8:
                    if (day >= 23) sign = AstroSign.Virgo;
                    else sign = AstroSign.Leo;
                    break;
                case 9:
                    if (day >= 23) sign = AstroSign.Libra;
                    else sign = AstroSign.Virgo;
                    break;
                case 10:
                    if (day >= 23) sign = AstroSign.Scorpio;
                    else sign = AstroSign.Libra;
                    break;
                case 11:
                    if (day >= 22) sign = AstroSign.Sagittarius;
                    else sign = AstroSign.Scorpio;
                    break;
                case 12:
                    if (day >= 22) sign = AstroSign.Capricorn;
                    else sign = AstroSign.Sagittarius;
                    break;
                default: sign = AstroSign.Aries;
                    break;
            }

            return sign;
        }
    }
}

