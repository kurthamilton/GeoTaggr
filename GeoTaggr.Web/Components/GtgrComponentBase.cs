using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace GeoTaggr.Web.Components;

public abstract class GtgrComponentBase : ComponentBase
{
    [Inject]
    protected IDialogService DialogService { get; set; } = default!;

    protected async Task<bool> ConfirmAsync(string title, string? message, string buttonText)
    {
        if (string.IsNullOrEmpty(message))
        {
            return true;
        }

        bool? result = await DialogService.ShowMessageBox(
                title,
                message,
                yesText: buttonText,
                cancelText: "Cancel");

        return result ?? false;
    }
}
