using src.Dto;

namespace src.ViewModels
{
    public class CashierCreateViewModel
    {
        public string CashierName { get; set; }
        public long BranchId { get; set; }
        public long CityId { get; set; }
        public string? BranchName { get; set; }
        public string? CityName { get; set; }
        public List<CityDto> Cities { get; set; } = new List<CityDto>();
    }
}
