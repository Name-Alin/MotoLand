using System;
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
    public class IndexModel : PageModel
    {
        private readonly MotoLand.Data.MotoLandContext _context;

        public IndexModel(MotoLand.Data.MotoLandContext context)
        {
            _context = context;
        }

        public IList<DealerMoto> DealerMoto { get;set; }

        public async Task OnGetAsync()
        {
            DealerMoto = await _context.DealerMoto.ToListAsync();
        }
    }
}
