﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotoLand.Data;
using MotoLand.Models;

namespace MotoLand.Pages.Dealers
{
    public class DeleteModel : PageModel
    {
        private readonly MotoLand.Data.MotoLandContext _context;

        public DeleteModel(MotoLand.Data.MotoLandContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DealerMoto DealerMoto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DealerMoto = await _context.DealerMoto.FirstOrDefaultAsync(m => m.ID == id);

            if (DealerMoto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DealerMoto = await _context.DealerMoto.FindAsync(id);

            if (DealerMoto != null)
            {
                _context.DealerMoto.Remove(DealerMoto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
