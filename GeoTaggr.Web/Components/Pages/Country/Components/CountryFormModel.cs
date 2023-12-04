using System.ComponentModel.DataAnnotations;

namespace GeoTaggr.Web.Components.Pages.Country.Components;

public class CountryFormModel(string name)
{
    [Required]
    public string Name { get; set; } = name;
}
