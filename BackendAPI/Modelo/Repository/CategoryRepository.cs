using Newtonsoft.Json;

namespace BackendAPI.Modelo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        List<Category> _categorys = new List<Category>();

        public CategoryRepository()
        {
            _categorys = LoadCategoryList();
        }
        public List<Category> LoadCategoryList()
        {
            string path = @"data\categorys.json";
            StreamReader jsonStream = File.OpenText(path);

            var json = jsonStream.ReadToEnd();

            Category[] category = JsonConvert.DeserializeObject<Category[]>(json);

            return category.ToList();

        }
        public int CategoryRepositoryLength()
        {
            return this._categorys.Count;
        }

        public Category FindCategoryById(int ID)
        {

            foreach (var category in this._categorys)
            {
                if (category.CategoryID == ID)
                {
                    return category;
                }
            }
            throw new Exception("Wrong ID for CategoryList");
        }
    }


}

