using Microsoft.JSInterop;

namespace WfhTracker.Client.Components.UI
{
    public partial class Calculator
    {
        // TODO: financial years
        private DateOnly fromDate = DateOnly.FromDateTime(DateTime.Today);
        private DateOnly toDate = DateOnly.FromDateTime(DateTime.Today);
        private decimal rate = 0.7m;
        private decimal? calculationResult = null;
        private decimal? totalHours = null;

        private async Task CalculateTotalAsync()
        {
            // Needs unit testing. Move to service layer via an API.
            var entries = await entryService.GetEntriesAsync();

            if (fromDate > toDate)
            {
                // Display an error message or handle the case where the from date is after the to date
                calculationResult = null;
                totalHours = null;
                return;
            }

            var filteredEntries = entries.Where(e => e.Date >= fromDate && e.Date <= toDate).ToList();

            var totalHoursWorked = filteredEntries.Sum(e => e.HoursWorked);
            totalHours = Convert.ToDecimal(totalHoursWorked);
            calculationResult = totalHours * rate;
        }

        private string GetDescription()
        {
            return $"${calculationResult?.ToString("F2")} claimed using fixed rate over {totalHours?.ToString("F1")} hours";
        }

        private async Task CopyToClipboard()
        {
            var description = GetDescription();
            await JSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", description);
        }
    }
}