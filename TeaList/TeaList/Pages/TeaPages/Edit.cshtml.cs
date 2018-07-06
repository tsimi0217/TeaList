using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeaList.Model;

namespace TeaList.Pages.TeaPages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
        _db = db;
        }
        [BindProperty]
        public Teas Tea { get; set; }
        [TempData]
    public string afterAddMessage { get; set; }

    public void OnGet(int id)
        {
            Tea = _db.TeaTable.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var teaInDb = _db.TeaTable.Find(Tea.ID);
                teaInDb.Name = Tea.Name;
                teaInDb.Type = Tea.Type;
                teaInDb.hasBeenUsed = Tea.hasBeenUsed;

                await _db.SaveChangesAsync();
                afterAddMessage = "Tea updated successfully!";

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}