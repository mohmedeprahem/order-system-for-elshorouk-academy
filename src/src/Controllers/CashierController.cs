using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using src.Dto;
using src.Models;
using src.Repositories;
using src.ViewModels;

namespace src.Controllers
{
    public class CashierController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public CashierController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> Index()
        {
            var cashiers = await _unitOfWork
                .CashierRepository
                .getAllCashiers(["Branch", "Branch.City"]);

            var model = cashiers
                .Select(
                    cashier =>
                        new CashierIndexViewModel
                        {
                            Id = cashier.Id,
                            CashierName = cashier.CashierName,
                            BranchName = cashier.Branch.BranchName,
                            CityName = cashier.Branch.City.CityName
                        }
                )
                .ToList();

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var cities = await _unitOfWork.CityRepository.GetCities(["Branches"]);

            var model = new CashierCreateViewModel
            {
                Cities = cities
                    .Select(
                        x =>
                            new CityDto
                            {
                                Id = x.Id,
                                CityName = x.CityName,
                                Branches = x.Branches
                                    .Select(
                                        y => new BranchDto { Id = y.Id, BranchName = y.BranchName }
                                    )
                                    .ToList()
                            }
                    )
                    .ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CashierCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            Cashier cashier = new Cashier
            {
                CashierName = model.CashierName,
                BranchId = (int)model.BranchId
            };

            await _unitOfWork.CashierRepository.AddCashier(cashier);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var cashier = await _unitOfWork
                .CashierRepository
                .GetCashierById(id, ["InvoiceHeaders"]);

            if (cashier == null)
            {
                return View("NotFound");
            }

            if (cashier.InvoiceHeaders.Count > 0)
            {
                return Json(
                    new
                    {
                        success = false,
                        message = "Cannot delete cashier with associated invoices."
                    }
                );
            }

            await _unitOfWork.CashierRepository.DeleteCashier(cashier);

            await _unitOfWork.SaveChangesAsync();

            return Json(new { success = true, message = "Cashier deleted successfully." });
        }
    }
}
