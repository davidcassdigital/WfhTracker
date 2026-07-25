namespace WfhTracker.Shared.Models
{
    public class Entry
    {
        public Guid Id { get; set; }

        public DateOnly Date { get; set; }

        public decimal HoursWorked { get; set; }
    }
}
