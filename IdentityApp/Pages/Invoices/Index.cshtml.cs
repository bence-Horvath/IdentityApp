using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityApp.Data;
using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IdentityApp.Authorization;

namespace IdentityApp.Pages.Invoices
{
    [AllowAnonymous]
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IList<Invoice> Invoice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (Context.Invoice != null)
            {

                var invoices = from i in Context.Invoice select i;

                var isManager = User.IsInRole(Constants.InvoiceManagersRole);

                var isAdmin = User.IsInRole(Constants.InvoiceAdminRole);

                var currentUserID = UserManager.GetUserId(User);


                if(!isManager && !isAdmin)
                {
                    invoices = invoices.Where(i => i.CreatorId == currentUserID);
                }


                Invoice = await invoices.ToListAsync();
            }



        }
    }
}
