using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories;
using src.ViewModels;

namespace src.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceRepository _invoiceRepository;
        private readonly UnitOfWork _unitOfWork;

        public InvoiceController(InvoiceRepository invoiceRepository, UnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
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

        public async Task<ActionResult> Details(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceById(
                id,
                ["InvoiceDetails", "Cashier"]
            );

            if (invoice == null)
            {
                return View();
            }
            else
            {
                var model = new InvoiceDetailsViewModel
                {
                    InvoiceId = invoice.Id,
                    InvoiceDate = invoice.Invoicedate,
                    CashierName = invoice.Cashier.CashierName,
                    CustomerName = invoice.CustomerName,
                    Items = invoice
                        .InvoiceDetails
                        .Select(
                            item =>
                                new InvoiceItemViewModel
                                {
                                    ItemName = item.ItemName,
                                    ItemPrice = item.ItemPrice,
                                    ItemCount = item.ItemCount,
                                }
                        )
                        .ToList()
                };

                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateInvoiceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InvoiceHeader invoice = new InvoiceHeader
                    {
                        CustomerName = model.CustomerName,
                        Invoicedate = model.InvoiceDate,
                        CashierId = (int)model.CashierId,
                        BranchId = model.BranchId
                    };

                    await _unitOfWork.BeginTransactionAsync();

                    InvoiceHeader result = await _unitOfWork.InvoiceRepository.AddInvoice(invoice);

                    await _unitOfWork.SaveChangesAsync();

                    if (result != null)
                    {
                        foreach (var item in model.Items)
                        {
                            InvoiceDetail detail = new InvoiceDetail
                            {
                                ItemName = item.ItemName,
                                ItemPrice = item.ItemPrice,
                                ItemCount = item.ItemCount,
                                InvoiceHeaderId = result.Id
                            };

                            await _unitOfWork.InvoiceRepository.AddInvoiceDetail(detail);
                        }
                    }
                }
                else
                {
                    return View(model);
                }
                await _unitOfWork.CommitAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return View();
            }
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Cashiers = await _unitOfWork.CashierRepository.getAllCashiers();

            return View();
        }
    }
}
