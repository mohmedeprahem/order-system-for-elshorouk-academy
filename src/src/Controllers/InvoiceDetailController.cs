using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Repositories;
using src.ViewModels;

namespace src.Controllers
{
    public class InvoiceDetailController : Controller
    {
        private readonly InvoiceRepository _invoiceRepository;
        private readonly UnitOfWork _unitOfWork;

        public InvoiceDetailController(InvoiceRepository invoiceRepository, UnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] InvoiceDetailCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invoice = await _unitOfWork.InvoiceRepository.GetInvoiceById(model.InvoiceHeaderId);

            if (invoice == null)
            {
                return NotFound();
            }

            var invoiceDetail = new InvoiceDetail
            {
                ItemName = model.ItemName,
                ItemPrice = model.ItemPrice,
                ItemCount = model.ItemCount,
                InvoiceHeaderId = model.InvoiceHeaderId
            };

            await _unitOfWork.InvoiceRepository.AddInvoiceDetail(invoiceDetail);

            await _unitOfWork.SaveChangesAsync();

            return Ok(new { ItemId = invoiceDetail.Id });
        }
    }
}
