namespace WebAppMVCCourse.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category {CategoryID = 1, Name = "Piće", Description = "Piće"},
            new Category {CategoryID = 2, Name = "Slastice", Description = "Slastice"},
            new Category {CategoryID = 3, Name = "Meso", Description = "Meso"}
        };

        public static void AddCategory(Category category)
        {
            var maxID = _categories.Max(x => x.CategoryID);
            category.CategoryID = maxID + 1;
            _categories.Add(category);  
        }
        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryByID(int categoryID)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryID == categoryID);
            if (category != null)
            {
                return new Category
                {
                    CategoryID = category.CategoryID,
                    Name = category.Name,
                    Description = category.Description,
                };
            }

            return null;
        }

        public static void UpdateCategory(int categoryID, Category category)
        {
            if (categoryID != category.CategoryID) return;

            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryID == categoryID);
            if (categoryToUpdate != null )
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryID)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryID == categoryID);
            if (category != null )
            {
                _categories.Remove(category);
            }
        }
    }
}
