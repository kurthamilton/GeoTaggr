using GeoTaggr.Core.Extensions;
using Microsoft.AspNetCore.Components;

namespace GeoTaggr.Web.Common.Extensions;

public static class NavigationManagerExtensions
{
    public static bool IsActivePath(this NavigationManager navigationManager, string url,
        bool exactMatch = true)
    {
        Uri uri = new Uri(navigationManager.Uri);
        string actualPath = uri.LocalPath.EnsureTrailing("/");

        if (url == "/")
        {
            return actualPath == "/";
        }

        string linkPath = url.EnsureTrailing("/");
        return exactMatch
            ? actualPath.Equals(linkPath, StringComparison.InvariantCultureIgnoreCase)
            : actualPath.StartsWith(linkPath, StringComparison.InvariantCultureIgnoreCase);
    }
}
