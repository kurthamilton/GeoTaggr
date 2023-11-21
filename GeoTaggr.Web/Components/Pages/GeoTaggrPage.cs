using Microsoft.AspNetCore.Components;

namespace GeoTaggr.Web.Components.Pages
{
    public abstract class GeoTaggrPage : ComponentBase
    {
        protected int? UserId { get; } = 1;
    }
}
