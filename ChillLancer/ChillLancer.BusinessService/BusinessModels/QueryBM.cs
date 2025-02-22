namespace ChillLancer.BusinessService.BusinessModels
{
    public class QueryBM
    {
        public string? KeyWord { get; set; }
        public string? InField { get; set; }
        public string? Status { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
