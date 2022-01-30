using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoLand.Data;
using MotoLand.Models;

namespace MotoLand.Pages.Motorcycles
{
    public class CreateModel : PageModel
    {
        private readonly MotoLand.Data.MotoLandContext _context;

        public CreateModel(MotoLand.Data.MotoLandContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DealerID"] = new SelectList(_context.Set<DealerMoto>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Motorcycle Motorcycle { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Motorcycle.Add(Motorcycle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
