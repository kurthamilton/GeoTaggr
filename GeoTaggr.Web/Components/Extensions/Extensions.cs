namespace GeoTaggr.Web.Components.Extensions;
using MudSize = MudBlazor.Size;

public static class Extensions
{
    public static MudSize ToMudSize(this GtgrButtonSize buttonSize)
    {
        return buttonSize switch
        {
            GtgrButtonSize.Small => MudSize.Small,
            GtgrButtonSize.Large => MudSize.Large,
            _ => MudSize.Medium
        };
    }
}
