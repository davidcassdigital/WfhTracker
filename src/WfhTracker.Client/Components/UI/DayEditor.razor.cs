using Microsoft.AspNetCore.Components;
using WfhTracker.Shared.Models;

namespace WfhTracker.Client.Components.UI
{
    public partial class DayEditor
    {
        [Parameter]
        public DateTime SelectedDate { get; set; } = DateTime.Today;

        [Parameter]
        public EventCallback OnEntryModified { get; set; }

        private double hours = 0;
        private bool isSaving = false;
        private bool isDeleting = false;
        private bool IsDeleteDisabled => currentEntry == null || isDeleting;
        private string? errorMessage = null;
        private Entry? currentEntry = null;

        protected override async Task OnParametersSetAsync()
        {
            // Load existing entry for the selected date if it exists
            // TODO: Consider optimizing this by fetching only the entry for the selected date (new endpoint) instead of all entries
            var entries = await entryService.GetEntriesAsync();
            currentEntry = entries.FirstOrDefault(e => e.Date == DateOnly.FromDateTime(SelectedDate));

            if (currentEntry != null)
            {
                hours = (double)currentEntry.HoursWorked;
            }
            else
            {
                hours = 8.0;
            }

            errorMessage = null;
        }

        private async Task SaveEntry()
        {
            isSaving = true;
            errorMessage = null;

            try
            {
                var entry = new Entry
                {
                    Date = DateOnly.FromDateTime(SelectedDate),
                    HoursWorked = (decimal)hours,
                };

                if (currentEntry != null)
                {
                    // Update existing entry
                    entry.Id = currentEntry.Id;
                    await entryService.UpdateEntryAsync(entry.Id, entry);

                    await OnEntryModified.InvokeAsync();
                }
                else
                {
                    // Create new entry
                    await entryService.CreateEntryAsync(entry);

                    await OnEntryModified.InvokeAsync();
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Error saving entry: {ex.Message}";
            }
            finally
            {
                isSaving = false;
            }
        }

        private async Task DeleteEntry()
        {
            isDeleting = true;
            errorMessage = null;

            try
            {
                if (currentEntry != null)
                {
                    // Delete existing entry
                    await entryService.DeleteEntryAsync(currentEntry.Id);

                    await OnEntryModified.InvokeAsync();
                }
                else
                {
                    errorMessage = $"Error deleting entry";
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Error deleting entry: {ex.Message}";
            }
            finally
            {
                isDeleting = false;
            }
        }
    }
}