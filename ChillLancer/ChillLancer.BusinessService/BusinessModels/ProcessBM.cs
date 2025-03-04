namespace ChillLancer.BusinessService.BusinessModels
{
    public class ProcessBM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TaskName { get; set; } = null!;
        public string? TaskDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Cost { get; set; } = 0;
        public bool IsPaid { get; set; } = false;
        public string? Note { get; set; }
        public string Status { get; set; } = "Draft";
        //public Guid ProposalId { get; set; }

    }
    public class ProcessUpdateBM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TaskName { get; set; } = null!;
        public string? TaskDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Cost { get; set; } = 0;
        public bool IsPaid { get; set; } = false;
        public string? Note { get; set; }
        public string Status { get; set; } = "Draft";
        //public Guid ProposalId { get; set; }

    }
}
