using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Diagnostics.Metrics;

namespace ScheduleMixer.Shared.Pages;

public partial class IngredientsJsonTestTool : ComponentBase
{
    private List<Core.Json.Ingredient>? _ingredients;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _ingredients = Core.Json.Ingredient.FromJson(File.ReadAllText(@"C:\Users\SET\Downloads\ingredients.json"));

            _ingredients.ForEach(async ingredient =>
            {
                var baseEffect = Core.Objects.Effect.GetEffectFromString(ingredient.BaseEffect);
                ingredient.Replacements.ToList().ForEach(replacement =>
                {
                    bool canSave = true;
                    if (baseEffect.Replacements.ContainsKey(Core.Objects.Effect.GetTypeFromString(replacement.Key)))
                    {
                        Console.WriteLine($"===========================\n" +
                                          $"Ingredient: {ingredient.Name}\n" +
                                          $"Replacement KEY: {replacement.Key}\n" +
                                          $"Already exists!\n");
                        canSave = false;
                        if (baseEffect.Replacements[Core.Objects.Effect.GetTypeFromString(replacement.Key)] !=
                            Core.Objects.Effect.GetTypeFromString(replacement.Value))
                        {
                            Console.WriteLine($"===========================\n" +
                                              $"Ingredient: {ingredient.Name}\n" +
                                              $"Original: {baseEffect.Replacements[Core.Objects.Effect.GetTypeFromString(replacement.Key)].ToString().ToLower()}\n" +
                                              $"Replacement: {replacement.Key}\n");
                        }
                    }
                    if (canSave)
                    {
                        var baseReplacements = new Dictionary<Core.Objects.EffectType, Core.Objects.EffectType>(baseEffect.Replacements)
                            { {
                                Core.Objects.Effect.GetTypeFromString(replacement.Key),
                                Core.Objects.Effect.GetTypeFromString(replacement.Value)
                            } };
                        baseEffect.Replacements = baseReplacements;
                    }
                });
            });
            StateHasChanged();
        }
    }
}