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
    public class CreateModel : MotoCategoriesPageModel
    {
        private readonly MotoLand.Data.MotoLandContext _context;

        public CreateModel(MotoLand.Data.MotoLandContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DealerID"] = new SelectList(_context.Set<DealerMoto>(), "ID", "Name");
            var moto = new Motorcycle();
            moto.MotoCategories = new List<MotoCategory>();
            PopulateAssignedCategoryData(_context, moto);

            return Page();
        }

        [BindProperty]
        public Motorcycle Motorcycle { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newMoto = new Motorcycle();
            if (selectedCategories != null)
            {
                newMoto.MotoCategories = new List<MotoCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new MotoCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newMoto.MotoCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Motorcycle>(
            newMoto,
            "Motorcycle",
            i => i.brand, i => i.model,
            i => i.price, i => i.year, i => i.DealerID))
            {
                _context.Motorcycle.Add(newMoto);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newMoto);
            return Page();
        }
    }
}
