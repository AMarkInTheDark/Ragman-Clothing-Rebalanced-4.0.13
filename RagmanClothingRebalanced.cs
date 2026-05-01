using System.Reflection;
using System.Text.Json;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Services;

namespace RagmanClothingRebalanced;

public class SuitPatch
{
    public string SuiteId { get; set; } = "";
    public int LoyaltyLevel { get; set; } = 1;
    public int ProfileLevel { get; set; } = 1;
    public List<string> QuestRequirements { get; set; } = [];
    public List<string> AchievementRequirements { get; set; } = [];
    public int Price { get; set; } = 0;
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 3)]
public class RagmanClothingRebalanced(
    DatabaseService databaseService
) : IOnLoad
{
    public async Task OnLoad()
    {
        var modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        var dbFolder = Path.Combine(modFolder, "db");

        var suits = databaseService.GetTables().Traders["5ac3b934156ae10c4430e83c"].Suits;

        foreach (var file in Directory.GetFiles(dbFolder, "*.json"))
        {
            var patches = JsonSerializer.Deserialize<List<SuitPatch>>(
                File.ReadAllText(file),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (patches == null) continue;

            foreach (var patch in patches)
            {
                foreach (var suit in suits)
                {
                    if (suit.SuiteId != patch.SuiteId) continue;

                    suit.ExternalObtain = false;
                    suit.InternalObtain = true;
                    suit.Requirements.LoyaltyLevel = patch.LoyaltyLevel;
                    suit.Requirements.ProfileLevel = patch.ProfileLevel;
                    suit.Requirements.QuestRequirements = patch.QuestRequirements;
                    suit.Requirements.AchievementRequirements = patch.AchievementRequirements;
                    suit.Requirements.ItemRequirements =
                    [
                        new()
                        {
                            Count = patch.Price,
                            Tpl = "5449016a4bdc2d6f028b456f",
                            OnlyFunctional = true,
                            Type = "ItemRequirement"
                        }
                    ];
                    break;
                }
            }
        }

        await Task.CompletedTask;
    }
}