using Microsoft.AspNetCore.Components;

namespace GeoTaggr.Web.Components.Pages
{
    public abstract class GtgrPage : ComponentBase
    {
        protected int? UserId { get; } = 1;
    }
}
