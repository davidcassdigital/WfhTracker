using System.Security.Claims;

namespace WfhTracker.Client.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetDisplayName(this ClaimsPrincipal user)
    {
        return //user.FindFirst("name")?.Value
            user.FindFirst("preferred_username")?.Value
            ?? user.FindFirst("email")?.Value
            ?? user.FindFirst("emails")?.Value
            ?? "Unknown User";
    }

    public static string GetInitials(this ClaimsPrincipal user)
    {
        var name = GetDisplayName(user);

        return string.Concat(
            name.Split([' ', '@', '.'], StringSplitOptions.RemoveEmptyEntries)
                .Take(2)
                .Select(s => char.ToUpperInvariant(s[0])));
    }
}