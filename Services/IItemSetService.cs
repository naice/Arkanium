using Arkanium.Model;

namespace Arkanium.Services;

public interface IItemSetService
{
    public ValueTask<IList<ItemSet>> GetItemSetsAsync();
    public ValueTask SaveChanges(); 
}
