namespace WfhTracker.Shared.Models
{
    public class WorkFromHomeEntry
    {
        public Guid Id { get; set; }

        public DateOnly Date { get; set; }

        public decimal HoursWorked { get; set; }

        public string? Notes { get; set; }
    }
}
