namespace Arkanium.Model;

public class ArkItemData
{
	public string ItemId { get; set; } = string.Empty;
	public string ItemName { get; set; } = string.Empty;
	public string GFICode { get; set; } = string.Empty;
	public string Image32Source { get; set; } = string.Empty;
	public string Image120Source { get; set; } = string.Empty;

}

public class ArkCreatureData
{
	public string CreatureId { get; set; } = string.Empty;
	public string CreatureName { get; set; } = string.Empty;
	public string SpawnDino { get; set; } = string.Empty;
	public string Summon { get; set; } = string.Empty;
	public string Image48Source { get; set; } = string.Empty;
	public string Image120Source { get; set; } = string.Empty;
}

