namespace GeoTaggr.Web.Components.Shared.Navs;

public class GtgrNavItem(string text, string? url = null)
{
    public string Text { get; } = text;

    public string? Url { get; set; } = url;
}
