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
        public MotoData Moto { get; set; }
        public int MotoID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            //Motorcycle = await _context.Motorcycle
            //    .Include(m => m.DealerMoto).ToListAsync();

            Moto = new MotoData();

            Moto.Moto = await _context.Motorcycle.Include(b => b.DealerMoto)
            .Include(b => b.MotoCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.brand)
            .ToListAsync();
            if (id != null)
            {
                MotoID = id.Value;
                Motorcycle Motor = Moto.Moto
                .Where(i => i.ID == id.Value).Single();
                Moto.Categories = Motor.MotoCategories.Select(s => s.Category);
            }
        }
    }
}
