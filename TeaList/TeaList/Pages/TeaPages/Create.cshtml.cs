using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeaList.Model;

namespace TeaList.Pages.TeaPages
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string afterAddMessage { get; set; }
        [BindProperty]
        public Teas Tea { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            } else
            {
                _db.TeaTable.Add(Tea);
                await _db.SaveChangesAsync();
                afterAddMessage = "New Tea Entered!";
                return RedirectToPage("Index");
            }
        }
    }
}