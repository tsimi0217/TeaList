using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeaList.Model;

namespace TeaList.Pages.TeaPages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;
        [TempData]
        public string afterAddMessage { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Teas> myTeas { get; set;  }
        //public void onGet method that is call before the page loads
        public async Task OnGetAsync()
        {
            myTeas = await _db.TeaTable.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var theTea = _db.TeaTable.Find(id);
            _db.TeaTable.Remove(theTea);
            await _db.SaveChangesAsync();
            afterAddMessage = "Tea deleted successfully!";
            return RedirectToPage();
        }
    }
}