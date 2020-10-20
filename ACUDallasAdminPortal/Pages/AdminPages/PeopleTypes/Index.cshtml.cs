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
    public class IndexModel : PageModel
    {
        private readonly ACUDallasAdminPortal.AdminModels.ACUDallasAdminContext _context;

        public IndexModel(ACUDallasAdminPortal.AdminModels.ACUDallasAdminContext context)
        {
            _context = context;
        }

        public IList<AdminModels.PeopleTypes> PeopleTypes { get;set; }

        public async Task OnGetAsync()
        {
            PeopleTypes = await _context.PeopleTypes.ToListAsync();
        }
    }
}
