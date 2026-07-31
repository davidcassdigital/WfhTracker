using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WfhTracker.Client.Components.UI
{
    public partial class Calculator
    {
        private DateOnly fromDate = DateOnly.FromDateTime(DateTime.Today);
        private DateOnly toDate = DateOnly.FromDateTime(DateTime.Today);
        private decimal rate = 0.7m;
        private decimal? calculationResult = null;
        private decimal? totalHours = null;
        private string selectedFinancialYear = "";
        private List<string> FinancialYears { get; set; } = [];

        protected override void OnInitialized()
        {
            PopulateFinancialYears();
            // Set to current financial year by default
            selectedFinancialYear = GetCurrentFinancialYear();
            SetDatesFromFinancialYear(selectedFinancialYear);
        }

        private void PopulateFinancialYears()
        {
            var currentYear = DateTime.Now.Year;
            // Generate financial years from 5 years ago to 2 years into the future
            for (int i = -5; i <= 2; i++)
            {
                var year = currentYear + i;
                FinancialYears.Add($"{year}-{year + 1}");
            }
            FinancialYears.Reverse(); // Show most recent first
        }

        private string GetCurrentFinancialYear()
        {
            var now = DateTime.Now;
            var fiscalStart = now.Month >= 7 ? now.Year : now.Year - 1;
            return $"{fiscalStart}-{fiscalStart + 1}";
        }

        private void OnFinancialYearChanged(ChangeEventArgs e)
        {
            selectedFinancialYear = e.Value?.ToString() ?? "";
            SetDatesFromFinancialYear(selectedFinancialYear);
        }

        private void SetDatesFromFinancialYear(string financialYear)
        {
            if (string.IsNullOrEmpty(financialYear))
                return;

            var parts = financialYear.Split('-');
            if (parts.Length == 2 && int.TryParse(parts[0], out var startYear))
            {
                fromDate = new DateOnly(startYear, 7, 1); // July 1st
                toDate = new DateOnly(startYear + 1, 6, 30); // June 30th
            }
        }

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
            return $"${calculationResult?.ToString("F2")} using the fixed rate method ({totalHours?.ToString("F1")} eligible hours × {rate:C1} per hour).";
        }

        private async Task CopyToClipboard()
        {
            var description = GetDescription();
            await JSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", description);
        }
    }
}