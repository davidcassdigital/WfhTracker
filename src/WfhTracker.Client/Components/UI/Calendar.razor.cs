using Microsoft.AspNetCore.Components;
using WfhTracker.Shared.Models;

namespace WfhTracker.Client.Components.UI
{
    // Needs a tidy...

    public partial class Calendar
    {
        [Parameter]
        public List<Entry> Entries { get; set; } = [];

        [Parameter]
        public EventCallback<DateTime> OnDateSelected { get; set; }


        private DateTime CurrentMonth = DateTime.Now;
        private DateTime selectedDate = DateTime.Today;
        private readonly string[] DayNames = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

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
            var isCurrentMonth = date.Month == CurrentMonth.Month;
            var isToday = date.Date == DateTime.Today;
            var isSelected = date.Date == selectedDate.Date;
            var hasEntry = HasEntry(date);

            var baseClass = "p-2 rounded cursor-pointer transition aspect-square relative text-sm";

            if (isSelected)
            {
                return $"{baseClass} bg-zinc-500 text-white hover:bg-zinc-600";
            }
            else if (hasEntry)
            {
                return $"{baseClass} bg-zinc-800 text-white border-2 border-amber-600 hover:bg-zinc-700";
            }
            else if (isToday)
            {
                return $"{baseClass} bg-zinc-800 text-white hover:bg-zinc-700";
            }
            else if (isCurrentMonth)
            {
                return $"{baseClass} bg-zinc-800 text-white hover:bg-zinc-700";
            }
            else
            {
                return $"{baseClass} bg-zinc-950 text-zinc-500 hover:bg-zinc-800";
            }
        }

        private bool HasEntry(DateTime date)
        {
            return Entries.Exists(e => e.Date == DateOnly.FromDateTime(date));
        }

        private static string GetDayNumberClass(DateTime date)
        {
            var isToday = date.Date == DateTime.Today;

            if (isToday)
            {
                return "absolute top-1 left-1 text-xs sm:text-sm inline-flex h-4 w-4 sm:h-5 sm:w-5 md:h-6 md:w-6 items-center justify-center rounded-full bg-amber-600 text-zinc-950 font-semibold";
            }

            return "absolute top-1 left-1 text-xs sm:text-sm";
        }
    }
}