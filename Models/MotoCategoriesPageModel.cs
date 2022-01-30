using Microsoft.AspNetCore.Mvc.RazorPages;
using MotoLand.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoLand.Models
{
    public class MotoCategoriesPageModel : PageModel
    {

        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(MotoLandContext context, Motorcycle moto)
        {
            var allCategories = context.Category;
            var motoCategories = new HashSet<int>(
            moto.MotoCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = motoCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateMotoCategories(MotoLandContext context, string[] selectedCategories, Motorcycle motoToUpdate)
        {
            if (selectedCategories == null)
            {
                motoToUpdate.MotoCategories = new List<MotoCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var motoCategories = new HashSet<int>
            (motoToUpdate.MotoCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!motoCategories.Contains(cat.ID))
                    {
                        motoToUpdate.MotoCategories.Add(
                        new MotoCategory
                        {
                            MotoID = motoToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (motoCategories.Contains(cat.ID))
                    {
                        MotoCategory courseToRemove
                        = motoToUpdate
                        .MotoCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }


    }
}
