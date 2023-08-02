using IdentityApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    public class IndexModel : PageModel
    {

        public Dictionary<string, int> revenueSubmitted;
        public Dictionary<string, int> revenueRejected;
        public Dictionary<string, int> revenueApproved;

        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            revenueSubmitted = InitDict(revenueSubmitted);
            revenueRejected = InitDict(revenueRejected);
            revenueApproved = InitDict(revenueApproved);

            var invoices = _context.Invoice.ToList();

            if (invoices != null)
            {

                foreach (var invoice in invoices)
                {

                    switch (invoice.Status)
                    {
                        case Models.InvoiceStatus.Submitted:
                            revenueSubmitted[invoice.InvoiceMonth] += (int)invoice.InvoiceAmount;
                            break;
                        case Models.InvoiceStatus.Approved:
                            revenueRejected[invoice.InvoiceMonth] += (int)invoice.InvoiceAmount;
                            break;
                        case Models.InvoiceStatus.Rejected:
                            revenueApproved[invoice.InvoiceMonth] += (int)invoice.InvoiceAmount;
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine( "Invoice is null");


        }

        private Dictionary<string, int> InitDict(Dictionary<string, int> dict)
        {
            dict = new Dictionary<string, int>()
            {
                {"January", 0 },
                {"February", 0 },
                {"March", 0 },
                {"April", 0 },
                {"May", 0 },
                {"June", 0 },
                {"July", 0 },
                {"August", 0 },
                {"September", 0 },
                {"October", 0 },
                {"November", 0 },
                {"December", 0 },
            };

            return dict;
        }
    }
}