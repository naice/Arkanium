using Arkanium.Model;
using Arkanium.Navigation;
using Blazored.LocalStorage;

namespace Arkanium.Services;

public class ItemSetService : IItemSetService
{
    private const string KEY = "Arkanium_ItemSets";
    private readonly ILocalStorageService _localStorage;
    private readonly INavigationPanelService _navigationPanelService;
    private List<ItemSet>? _itemSets = null;

    public ItemSetService(ILocalStorageService localStorage, INavigationPanelService navigationPanelService)
    {
        _localStorage = localStorage;
        _navigationPanelService = navigationPanelService;
    }

    public async ValueTask<IList<ItemSet>> GetItemSetsAsync()
    {
        if (_itemSets != null)
            return _itemSets;
        
        try
        {
            _itemSets = await _localStorage.GetItemAsync<List<ItemSet>>(KEY);
        }
        catch (Exception)
        {
        }

        _itemSets ??= System.Text.Json.JsonSerializer.Deserialize<List<ItemSet>>("[{\"Items\":[{\"ItemId\":\"220\",\"ItemName\":\"Flak Helmet\",\"GFICode\":\"cheat gfi MetalHelmet 1 1 0\",\"Image32Source\":\"image/item/32/flak-helmet.png\",\"Image120Source\":\"image/item/120/flak-helmet.png\"},{\"ItemId\":\"219\",\"ItemName\":\"Flak Chestpiece\",\"GFICode\":\"cheat gfi MetalShirt 1 1 0\",\"Image32Source\":\"image/item/32/flak-chestpiece.png\",\"Image120Source\":\"image/item/120/flak-chestpiece.png\"},{\"ItemId\":\"222\",\"ItemName\":\"Flak Gauntlets\",\"GFICode\":\"cheat gfi MetalGloves 1 1 0\",\"Image32Source\":\"image/item/32/flak-gauntlets.png\",\"Image120Source\":\"image/item/120/flak-gauntlets.png\"},{\"ItemId\":\"218\",\"ItemName\":\"Flak Leggings\",\"GFICode\":\"cheat gfi MetalPants 1 1 0\",\"Image32Source\":\"image/item/32/flak-leggings.png\",\"Image120Source\":\"image/item/120/flak-leggings.png\"},{\"ItemId\":\"221\",\"ItemName\":\"Flak Boots\",\"GFICode\":\"cheat gfi MetalBoots 1 1 0\",\"Image32Source\":\"image/item/32/flak-boots.png\",\"Image120Source\":\"image/item/120/flak-boots.png\"},{\"ItemId\":\"131\",\"ItemName\":\"Longneck Rifle\",\"GFICode\":\"cheat gfi PrimalItem_WeaponOneShotRifle 1 1 0\",\"Image32Source\":\"image/item/32/longneck-rifle.png\",\"Image120Source\":\"image/item/120/longneck-rifle.png\"},{\"ItemId\":\"358\",\"ItemName\":\"Crossbow\",\"GFICode\":\"cheat gfi PrimalItem_WeaponCrossbow 1 1 0\",\"Image32Source\":\"image/item/32/crossbow.png\",\"Image120Source\":\"image/item/120/crossbow.png\"},{\"ItemId\":\"32\",\"ItemName\":\"Stone Arrow\",\"GFICode\":\"cheat gfi ArrowStone 100 1 0\",\"Image32Source\":\"image/item/32/stone-arrow.png\",\"Image120Source\":\"image/item/120/stone-arrow.png\"},{\"ItemId\":\"70\",\"ItemName\":\"Tranquilizer Arrow\",\"GFICode\":\"cheat gfi ArrowTranq 100 1 0\",\"Image32Source\":\"image/item/32/tranquilizer-arrow.png\",\"Image120Source\":\"image/item/120/tranquilizer-arrow.png\"},{\"ItemId\":\"RefinedTranqDart\",\"ItemName\":\"Shocking Tranquilizer Dart\",\"GFICode\":\"cheat gfi RefinedTranqDart 100 1 0\",\"Image32Source\":\"image/item/32/shocking-tranquilizer-dart.png\",\"Image120Source\":\"image/item/120/shocking-tranquilizer-dart.png\"},{\"ItemId\":\"PrimalItemAmmo_TranqDart\",\"ItemName\":\"Tranquilizer Dart\",\"GFICode\":\"cheat gfi PrimalItemAmmo_TranqDart 100 1 0\",\"Image32Source\":\"image/item/32/tranquilizer-dart.png\",\"Image120Source\":\"image/item/120/tranquilizer-dart.png\"}],\"Image32Source\":\"image/item/32/flak-helmet.png\",\"Image120Source\":\"image/item/120/flak-helmet.png\",\"Name\":\"Flak Armor Set\",\"Id\":\"317510fa-a0dd-4ab9-8115-4f8d15bd36bd\"}]") ?? new();
        return _itemSets;
    }

    public async ValueTask SaveChanges()
    {
        await _localStorage.SetItemAsync(KEY, _itemSets);
        await _navigationPanelService.UpdateItemsFor(typeof(ItemSetsSubItemProvider));
    }
}
