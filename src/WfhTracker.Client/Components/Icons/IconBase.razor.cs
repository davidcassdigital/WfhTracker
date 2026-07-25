using Microsoft.AspNetCore.Components;

namespace WfhTracker.Client.Components.Icons;

public partial class IconBase : ComponentBase
{
    /// <summary>
    /// Optional CSS class to apply to the SVG element.
    /// </summary>
    [Parameter]
    public string? Class { get; set; }
}