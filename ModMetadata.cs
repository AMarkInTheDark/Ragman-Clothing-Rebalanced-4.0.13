using SPTarkov.Server.Core.Models.Spt.Mod;

namespace RagmanClothingRebalanced;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.amarkinthedark.ragmanclothingrebalanced";
    public override string Name { get; init; } = "RagmanClothingRebalanced";
    public override string Author { get; init; } = "AMarkInTheDark (Marrko)";
    public override SemanticVersioning.Version Version { get; init; } = new("1.0.0");
    public override SemanticVersioning.Range SptVersion { get; init; } = new("~4.0.13");
    public override string License { get; init; } = "MIT";
    public override bool? IsBundleMod { get; init; } = false;
    public override Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; } = null;
    public override string? Url { get; init; } = null;
    public override List<string>? Contributors { get; init; } = null;
    public override List<string>? Incompatibilities { get; init; } = null;
}
