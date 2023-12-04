using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace GeoTaggr.Web.Components;

public abstract class GtgrComponentBase : ComponentBase
{
    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    [Inject]
    private ISnackbar SnackbarService { get; set; } = default!;

    protected Task ShowMessageAsync(string? message)
    {
        if (string.IsNullOrEmpty(message))
        {
            return Task.CompletedTask;
        }

        SnackbarService.Configuration.PositionClass = Defaults.Classes.Position.BottomRight;
        SnackbarService.Add(message, configure: ConfigureSnackbar);
        return Task.CompletedTask;
    }

    protected Task ShowMessageAsync(RenderFragment message)
    {
        SnackbarService.Add(message, configure: ConfigureSnackbar);
        return Task.CompletedTask;
    }

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

    private void ConfigureSnackbar(SnackbarOptions options)
    {
        options.VisibleStateDuration = 10000;
    }
}
