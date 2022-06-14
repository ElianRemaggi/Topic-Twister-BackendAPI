using System.Collections.Generic;

public interface ICategoryRepository 
{
    public Category FindCategoryById(int ID);
    public List<Category> LoadCategoryList();
    public int CategoryRepositoryLength();
}
