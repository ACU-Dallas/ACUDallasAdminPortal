using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACUDallasAdminPortal.AdminModels;

namespace ACUDallasAdminPortal.Pages.AdminPages.PeopleTypes
{
    public class EditModel : PageModel
    {
        private readonly ACUDallasAdminPortal.AdminModels.ACUDallasAdminContext _context;

        public EditModel(ACUDallasAdminPortal.AdminModels.ACUDallasAdminContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdminModels.PeopleTypes PeopleTypes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PeopleTypes = await _context.PeopleTypes.FirstOrDefaultAsync(m => m.PeopleTypeId == id);

            if (PeopleTypes == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PeopleTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleTypesExists(PeopleTypes.PeopleTypeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PeopleTypesExists(int id)
        {
            return _context.PeopleTypes.Any(e => e.PeopleTypeId == id);
        }
    }
}
