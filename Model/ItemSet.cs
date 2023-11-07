namespace Arkanium.Model;

public class ItemSet
{
	public List<ArkItemData> Items { get; set; } = new List<ArkItemData>();
	public string Image32Source { get; set; } = string.Empty;
	public string Image120Source { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public Guid Id { get; set; } = Guid.NewGuid();
}