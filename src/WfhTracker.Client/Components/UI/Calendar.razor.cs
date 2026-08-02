using Microsoft.AspNetCore.Components;
using WfhTracker.Shared.Models;

namespace WfhTracker.Client.Components.UI
{
    public partial class Calendar
    {
        [Parameter]
        public List<Entry> Entries { get; set; } = [];

        [Parameter]
        public EventCallback<DateTime> OnDateSelected { get; set; }


        private DateTime CurrentMonth = DateTime.Now;
        private DateTime selectedDate = DateTime.Today;

        private async Task HandleDateSelect(DateTime date)
        {
            selectedDate = date;

            // Change month if the selected date is from a different month
            if (date.Month != CurrentMonth.Month || date.Year != CurrentMonth.Year)
            {
                CurrentMonth = new DateTime(date.Year, date.Month, 1);
            }

            await OnDateSelected.InvokeAsync(date);
        }

        private void PreviousMonth()
        {
            CurrentMonth = CurrentMonth.AddMonths(-1);
        }

        private void NextMonth()
        {
            CurrentMonth = CurrentMonth.AddMonths(1);
        }

        private List<DateTime> GetCalendarDays()
        {
            var days = new List<DateTime>();
            var firstDayOfMonth = new DateTime(CurrentMonth.Year, CurrentMonth.Month, 1);
            var daysInMonth = DateTime.DaysInMonth(CurrentMonth.Year, CurrentMonth.Month);
            var startDate = firstDayOfMonth.AddDays(-(int)firstDayOfMonth.DayOfWeek);

            for (int i = 0; i < 42; i++) // 6 weeks * 7 days
            {
                days.Add(startDate.AddDays(i));
            }

            return days;
        }

        private string GetDayClass(DateTime date)
        {
            var isCurrentDate = date.Date == DateTime.Today;
            var isCurrentMonth = date.Month == CurrentMonth.Month;
            var isSelected = date.Date == selectedDate.Date;
            var hasEntry = HasEntry(date);

            var baseClass = "p-2 rounded cursor-pointer transition aspect-square relative text-xs md: text-lg hover:bg-zinc-700";

            // Add amber border
            if (isSelected)
            {
                baseClass = $"{baseClass} border-2 border-amber-600";
            }

            // Set the day number colour
            if (hasEntry)
            {
                baseClass = $"{baseClass} text-amber-600";
            }
            else if (isCurrentMonth)
            {
                baseClass = $"{baseClass} text-white";
            }
            else
            {
                baseClass = $"{baseClass} text-zinc-500";
            }

            // Set the background colour
            if (isCurrentMonth)
            {
                baseClass = $"{baseClass} bg-zinc-800";
            }
            else
            {
                baseClass = $"{baseClass} bg-zinc-950";
            }

            if (isCurrentDate)
            {
                baseClass = $"{baseClass} underline decoration-2 underline-offset-2";
            }

            return baseClass;
        }

        private bool HasEntry(DateTime date)
        {
            return Entries.Exists(e => e.Date == DateOnly.FromDateTime(date));
        }
    }
}