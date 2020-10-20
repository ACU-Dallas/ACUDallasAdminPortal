using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ACUDallasAdminPortal.AdminModels;

namespace ACUDallasAdminPortal.Pages.AdminPages.PeopleTypes
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
            return Page();
        }

        [BindProperty]
        public AdminModels.PeopleTypes PeopleTypes { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PeopleTypes.Add(PeopleTypes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
