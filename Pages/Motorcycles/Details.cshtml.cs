using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotoLand.Data;
using MotoLand.Models;

namespace MotoLand.Pages.Motorcycles
{
    public class DetailsModel : PageModel
    {
        private readonly MotoLand.Data.MotoLandContext _context;

        public DetailsModel(MotoLand.Data.MotoLandContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
