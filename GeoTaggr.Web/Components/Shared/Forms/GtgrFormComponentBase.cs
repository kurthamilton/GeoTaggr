using GeoTaggr.Core.Utils;
using Microsoft.AspNetCore.Components;

namespace GeoTaggr.Web.Components.Shared.Forms;

public abstract class GtgrFormComponentBase : GtgrComponentBase
{
    [Parameter]
    public string? HelpText { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public bool Required { get; set; }

    protected string AutoId { get; } = TextUtils.GenerateRandomAlphaString(5);

    protected IDictionary<string, object> ValidationAttributes { get; }
        = new Dictionary<string, object>();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        SetValidationAttributes();
    }

    private void SetValidationAttributes()
    {
        ValidationAttributes.Clear();

        if (Required)
        {
            ValidationAttributes.Add("required", "");
        }
    }
}
