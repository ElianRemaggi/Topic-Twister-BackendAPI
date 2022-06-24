using BackendAPI.Service;

namespace BackendAPI.Modelo.UseCases
{
    public class FindRandomCategoryListUseCase
    {
        private ICategoryRepository _categoryRepository;
        public FindRandomCategoryListUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> Execute()
        {
            try
            {
                List<Category> randomCategories = new List<Category>();
                List<Category> categoriesArray = _categoryRepository.LoadCategoryList();

                var random = new Random();
                for (int i = 0; i < 5; i++)
                {
                    int randomIndex = random.Next(categoriesArray.Count);
                    Category randomCategory = categoriesArray.ElementAt(randomIndex);

                    randomCategories.Add(randomCategory);
                    categoriesArray.Remove(randomCategory);
                }
                return randomCategories;
            }
            catch (Exception e)
            {
                throw new Exception("Find Category List:" + e.Message);
            }

        }
    }
}
