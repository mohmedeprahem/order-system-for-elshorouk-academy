using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
