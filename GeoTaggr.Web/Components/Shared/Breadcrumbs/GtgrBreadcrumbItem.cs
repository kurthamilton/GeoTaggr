namespace GeoTaggr.Web.Components.Shared.Breadcrumbs;

public class GtgrBreadcrumbItem(string text)
{
    public bool? Active { get; set; }

    public string Text { get; } = text;

    public string? Url { get; set; }
}
