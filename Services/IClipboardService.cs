namespace Arkanium.Services;

public interface IClipboardService
{
    Task CopyToClipboard(string text);
}
