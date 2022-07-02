using BackendAPI.Modelo.UseCases;

public class CreateNewRoundUseCase
{
    private ICategoryRepository _categoryRepository;

    public CreateNewRoundUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Round Execute(int roundNumber)
    {
        List<Category> categoryList = new FindRandomCategoryListUseCase(_categoryRepository).Execute();

        return new Round(categoryList,roundNumber);
    }
}