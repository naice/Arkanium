
namespace Arkanium.Navigation;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class NavigationPageAttribute : Attribute
{
    // This is a positional argument
    public NavigationPageAttribute(string text, string icon = "", int sort = 9999, Type? subItemProvider = null)
    {
        Text = text;
        Icon = icon;
        Sort = sort;
        SubItemProvider = subItemProvider;
    }

    public string Text { get; private set; }
    public string Icon { get; private set; }
    public int Sort { get; private set; }
    public Type? SubItemProvider { get; private set; }
}

public record NavigationItem(string Text, string Route, string Icon = "", int Sort = 9999, Type? SubItemProvider = null) 
{
    public List<NavigationItem> Items { get; set; } = new List<NavigationItem>();
}

public interface ISubItemProvider
{
    public Task<IEnumerable<NavigationItem>> GenerateItems(NavigationItem item);
}