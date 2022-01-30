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
    public class EditModel : PageModel
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
                .Include(m => m.DealerMoto).FirstOrDefaultAsync(m => m.ID == id);

            if (Motorcycle == null)
            {
                return NotFound();
            }
           ViewData["DealerID"] = new SelectList(_context.Set<DealerMoto>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Motorcycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotorcycleExists(Motorcycle.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MotorcycleExists(int id)
        {
            return _context.Motorcycle.Any(e => e.ID == id);
        }
    }
}
