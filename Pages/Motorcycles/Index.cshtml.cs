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
    public class IndexModel : PageModel
    {
        private readonly MotoLand.Data.MotoLandContext _context;

        public IndexModel(MotoLand.Data.MotoLandContext context)
        {
            _context = context;
        }

        public IList<Motorcycle> Motorcycle { get;set; }

        public async Task OnGetAsync()
        {
            Motorcycle = await _context.Motorcycle
                .Include(m => m.DealerMoto).ToListAsync();
        }
    }
}
