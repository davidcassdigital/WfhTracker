using WfhTracker.Shared.Models;

namespace WfhTracker.Client.Pages
{
    public partial class Home
    {
        private List<Entry> entries = [];
        private bool isLoading = true;
        private DateTime selectedDate = DateTime.Today;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                entries = await entryService.GetEntriesAsync();
                isLoading = false;
            }
            catch (Exception ex)
            {
                // Log error
                // Toast...
            }
            finally
            {
                isLoading = false;
            }
        }

        private void HandleDateSelected(DateTime selectedDate)
        {
            this.selectedDate = selectedDate;
        }

        private async Task HandleEntryModified()
        {
            // Refresh entries after an entry is modified
            entries = await entryService.GetEntriesAsync();
        }
    }
}