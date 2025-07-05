namespace ScheduleMixer.Shared.Core.Objects;

public class Product(Product? baseProduct = null) : Base
{
    public Product? BaseProduct { get; } = baseProduct;
    private List<Ingredient> Ingredients { get; } = [];

    public List<Effect> Effects
    {
        get
        {
            List<Effect> result = [];
            if (result.Count == 0)
            {
                result.AddRange(BaseProduct.Effects);
            }
            if (Ingredients.Count > 0)
            {
                foreach (var ingredient in Ingredients)
                {
                    if (ingredient.Effects.Count > 0)
                    {
                        foreach (var effect in ingredient.Effects)
                        {
                            foreach (var replacement in effect.Replacements)
                            {
                                if (result.Contains(Data.Effects[replacement.Key]))
                                {
                                    result.Remove(Data.Effects[replacement.Key]);
                                    result.Add(Data.Effects[replacement.Value]);
                                }
                            }
                            if (result.Count < 8 && !result.Contains(effect)) result.Add(effect);
                        }
                    }
                }
            }
            return result;
        }
    }

    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
    }
    public void RemoveIngredient(Ingredient ingredient)
    {
        Ingredients.Remove(ingredient);
    }
}