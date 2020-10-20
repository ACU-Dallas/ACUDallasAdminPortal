using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ACUDallasAdminPortal.AdminModels;

namespace ACUDallasAdminPortal.Pages.AdminPages.PeopleTypes
{
    public class DetailsModel : PageModel
    {
        private readonly ACUDallasAdminPortal.AdminModels.ACUDallasAdminContext _context;

        public DetailsModel(ACUDallasAdminPortal.AdminModels.ACUDallasAdminContext context)
        {
            _context = context;
        }

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
    }
}
