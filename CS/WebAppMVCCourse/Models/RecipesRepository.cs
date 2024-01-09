namespace WebAppMVCCourse.Models
{
    public static class RecipesRepository
    {
        private static List<Recipe> _recipes = new List<Recipe>()
        {
            new Recipe { RecipeID = 1, Title = "Sacher torta", Description = "Ukusna čokoladna torta", CategoryID =  1 },
            new Recipe { RecipeID = 2, Title = "Tjestenina carbonara", Description = "Ukusna tjestenina", CategoryID = 2 }
        };

        public static List<Recipe> GetRecipes() => _recipes;

        public static Recipe? GetRecipeByID(int recipeID)
        {
            var recipe = _recipes.FirstOrDefault(x => x.RecipeID == recipeID);
            if (recipe != null)
            {
                return new Recipe
                {
                    RecipeID = recipe.RecipeID,
                    Title = recipe.Title,
                    Description = recipe.Description,
                    Category = recipe.Category,
                };
            }

            return null;
        }

        public static void UpdateRecipe(int recipeID, Recipe recipe)
        {
            if (recipeID != recipe.RecipeID) return;

            var recipeToUpdate = _recipes.FirstOrDefault(x => x.RecipeID == recipeID);
            if (recipeToUpdate != null)
            {
                recipeToUpdate.Title = recipe.Title;
                recipeToUpdate.Description = recipe.Description;
                recipeToUpdate.Category = recipe.Category;
            }
        }
    }
}
