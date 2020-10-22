using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using ACUDallasAdminPortal.AdminModels;

namespace ACUDallasAdminPortal.Pages.AdminPages.People
{
    public class CreateModel : PageModel
    {
        private readonly ACUDallasAdminPortal.AdminModels.ACUDallasAdminContext _context;

        public CreateModel(ACUDallasAdminPortal.AdminModels.ACUDallasAdminContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PeopleTypeId"] = new SelectList(_context.PeopleTypes, "PeopleTypeId", "PeopleTypeDesc");
            return Page();
        }

        

        [BindProperty]
        public AdminModels.People People { get; set; }

        [BindProperty]
        public IFormFile FileUpload { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {    
            //var file = Path.Combine(_)
            //byte[] imgdata = System.IO.File.ReadAllBytes((this.HttpContext.Request.Form["People.Photo"].ToString()));
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.CopyToAsync(memoryStream);

                People.Photo = memoryStream.ToArray();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.People.Add(People);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
