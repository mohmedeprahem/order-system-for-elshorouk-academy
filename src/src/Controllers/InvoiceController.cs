using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Repositories;
using src.ViewModels;

namespace src.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceRepository _invoiceRepository;

        public InvoiceController(InvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<ActionResult> Index(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
        )
        {
            var invoices = await _invoiceRepository.GetAllInvoices(
                pageNumber,
                pageSize,
                ["InvoiceDetails"]
            );
            var model = invoices.Select(
                invoice =>
                    new InvoiceViewModel
                    {
                        InvoiceId = invoice.Id,
                        CustomerName = invoice.CustomerName,
                        InvoiceDate = invoice.Invoicedate,
                        TotalAmount = invoice
                            .InvoiceDetails
                            .Sum(item => item.ItemCount * item.ItemPrice)
                    }
            );

            return View(model);
        }
    }
}
