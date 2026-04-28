using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Services;

namespace RagmanClothingRebalanced;

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 3)]
public class RagmanClothingRebalanced(
    DatabaseService databaseService
) : IOnLoad
{
    public async Task OnLoad()
    {
        var suits = databaseService.GetTables().Traders["5ac3b934156ae10c4430e83c"].Suits;

        foreach (var suit in suits)
        {
            if (suit.SuiteId == "66043a3910bcdf80ff0e9f7c")
            {
                suit.Requirements.LoyaltyLevel = 1;
                suit.Requirements.ProfileLevel = 8;
                suit.Requirements.QuestRequirements = ["657315e4a6af4ab4b50f3459"];
                suit.Requirements.AchievementRequirements = [];
                suit.Requirements.ItemRequirements = [new() { Count = 64000, Tpl = "5449016a4bdc2d6f028b456f", OnlyFunctional = true, Type = "ItemRequirement" }];
            }
            else if (suit.SuiteId == "66043a8dc8949a435906e42c")
            {
                suit.Requirements.LoyaltyLevel = 1;
                suit.Requirements.ProfileLevel = 8;
                suit.Requirements.QuestRequirements = ["657315e4a6af4ab4b50f3459"];
                suit.Requirements.AchievementRequirements = [];
                suit.Requirements.ItemRequirements = [new() { Count = 48000, Tpl = "5449016a4bdc2d6f028b456f", OnlyFunctional = true, Type = "ItemRequirement" }];
            }
        }

        await Task.CompletedTask;
    }
}
