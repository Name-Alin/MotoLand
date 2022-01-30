using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoLand.Data;
using MotoLand.Models;

namespace MotoLand.Pages.Motorcycles
{
    public class EditModel : MotoCategoriesPageModel
    {
        private readonly MotoLand.Data.MotoLandContext _context;

        public EditModel(MotoLand.Data.MotoLandContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Motorcycle Motorcycle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Motorcycle = await _context.Motorcycle
             .Include(b => b.DealerMoto)
             .Include(b => b.MotoCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            if (Motorcycle == null)
            {
                return NotFound();
            }
           ViewData["DealerID"] = new SelectList(_context.Set<DealerMoto>(), "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var motoToUpdate = await _context.Motorcycle
            .Include(i => i.DealerMoto)
            .Include(i => i.MotoCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (motoToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Motorcycle>(
            motoToUpdate,
            "Moto",
            i => i.brand, i => i.model,
            i => i.price, i => i.year, i => i.DealerMoto))
            {
                UpdateMotoCategories(_context, selectedCategories, motoToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateMotoCategories(_context, selectedCategories, motoToUpdate);
            PopulateAssignedCategoryData(_context, motoToUpdate);
            return Page();
        }

        private bool MotorcycleExists(int id)
        {
            return _context.Motorcycle.Any(e => e.ID == id);
        }
    }
}
