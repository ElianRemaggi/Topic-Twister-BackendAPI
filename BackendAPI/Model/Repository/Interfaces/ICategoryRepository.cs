using System.Collections.Generic;

public interface ICategoryRepository 
{
    public Category FindCategoryById(int ID);
    public List<Category> LoadCategoryList(string path);
    public int CategoryRepositoryLength();
}
