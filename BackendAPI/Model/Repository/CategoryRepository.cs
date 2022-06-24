using Newtonsoft.Json;

namespace BackendAPI.Modelo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        List<Category> _categorys = new List<Category>();
        string _path;

        public CategoryRepository(string path)
        {
            _path = path;
            LoadCategoryList();
        }
        public List<Category> LoadCategoryList()
        {
            StreamReader jsonStream = File.OpenText(_path);

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

