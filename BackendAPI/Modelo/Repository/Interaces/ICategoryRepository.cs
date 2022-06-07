using System.Collections.Generic;

public interface ICategoryRepository 
{
    public Category FindCategoryById(string ID);
    public List<Category> LoadCategoryList();
    public int CategoryRepositoryLength();
}
