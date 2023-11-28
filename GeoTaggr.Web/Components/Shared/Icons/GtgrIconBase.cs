using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudIcons = MudBlazor.Icons;

namespace GeoTaggr.Web.Components.Shared.Icons;

public abstract class GtgrIconBase : GtgrComponentBase
{
    [Parameter]
    public GtgrIconType Type { get; set; }

    protected Color IconColor => Type switch
    {
        GtgrIconType.Delete => Color.Error,
        _ => Color.Inherit
    };

    protected string? HoverIcon => Type switch
    {
        GtgrIconType.Delete => MudIcons.Material.Filled.Delete,
        _ => null
    };

    protected string? Tooltip => Type switch
    {
        GtgrIconType.Delete => "Delete",
        _ => null
    };

    protected string? TypeIcon => Type switch
    {
        GtgrIconType.Delete => MudIcons.Material.Outlined.Delete,
        _ => null
    };
}
