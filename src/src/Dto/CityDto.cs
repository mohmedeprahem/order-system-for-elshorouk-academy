namespace src.Dto
{
    public class CityDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public List<BranchDto> Branches { get; set; } = new List<BranchDto>();
    }
}
