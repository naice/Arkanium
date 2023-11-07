using Arkanium.Model;
using Arkanium.Navigation;

namespace Arkanium.Services;

public class ItemSetsSubItemProvider : ISubItemProvider
{
    private readonly IItemSetService _itemSetService;

    public ItemSetsSubItemProvider(IItemSetService itemSetService)
    {
        _itemSetService = itemSetService;
    }

    public async Task<IEnumerable<NavigationItem>> GenerateItems(NavigationItem item)
    {
        return ((await _itemSetService.GetItemSetsAsync()) ?? Array.Empty<ItemSet>())
            .Select(x => new NavigationItem(x.Name, $"/itemset/{x.Id}", Image: x.Image32Source));
    }
}
