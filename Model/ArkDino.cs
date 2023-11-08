namespace Arkanium.Model;


public record ArkDinoData(
	ArkDino[] Creatures
);
public record ArkDinoCategory(
	string Name,
	bool IsMap = false,
	bool IsKind = false,
	bool IsTaming = false,
	bool IsRideable = false,
	bool IsDiet = false
);
public record ArkDino(
	string Id,
	string Name,
	string[] Paths,
	string[] Blueprints,
	string[] BlueprintsCharacter,
	string ImageSource,
	string[] Eats,
	string TamingNotice,
	string Description,
	string[] CarriedBy,
	ArkDinoCategory[] Categories
);