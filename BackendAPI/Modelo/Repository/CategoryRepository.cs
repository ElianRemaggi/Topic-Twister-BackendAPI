using Newtonsoft.Json;

namespace BackendAPI.Modelo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        List<Category> _categorys = new List<Category>();
        
        public CategoryRepository()
        {
          _categorys =  LoadCategoryList();
        }
        public List<Category> LoadCategoryList()
        {
            string path = @"data\categorys.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();

                Category[] category = JsonConvert.DeserializeObject<Category[]>(json);

                return category.ToList();
            }
        }
        public int CategoryRepositoryLength()
        {
            return this._categorys.Count;
        }

        public Category FindCategoryById(string ID)
        {
            throw new NotImplementedException();
        }


    }
}
