using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stroia_Alexia_Lab2.Data;
using Stroia_Alexia_Lab2.Models;
using Stroia_Alexia_Lab2.Models.ViewModels;

namespace Stroia_Alexia_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Stroia_Alexia_Lab2.Data.Stroia_Alexia_Lab2Context _context;

        public IndexModel(Stroia_Alexia_Lab2.Data.Stroia_Alexia_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoriesIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoriesIndexData();
            CategoryData.Category = await _context.Category
         .Include(c => c.BookCategories)
             .ThenInclude(bc => bc.Book).ThenInclude(b => b.Author)
         .OrderBy(c => c.CategoryName)
         .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                var category = CategoryData.Category
                    .SingleOrDefault(c => c.ID == id.Value);

                if (category != null)
                {
                    CategoryData.Books = category.BookCategories
                        .Select(bc => bc.Book)
                        .ToList();
                }
            }
        }
    }
}
