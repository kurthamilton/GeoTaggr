using System.ComponentModel.DataAnnotations;
using GeoTaggr.Web.Components.Shared.Forms.Selects;

namespace GeoTaggr.Web.Components.Pages.Tags.Index.Components;

public class CreateTagFormModel
{
    [Required]
    public SelectOption? Country { get; set; }

    [Required]
    public string Name { get; set; } = "";

    public string? Value { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    public string? Url { get; set; }
}
