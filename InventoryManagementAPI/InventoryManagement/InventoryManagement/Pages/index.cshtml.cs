using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;

namespace InventoryManagement.Pages
{
    public class indexModel : PageModel
    {
        private readonly InventoryManagement.Models.InventoryManagementContext _context;

        public indexModel(InventoryManagement.Models.InventoryManagementContext context)
        {
            _context = context;
        }

        public IList<TblUsersInfo> TblUsersInfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TblUsersInfo = await _context.TblUsersInfos.ToListAsync();
        }
    }
}
