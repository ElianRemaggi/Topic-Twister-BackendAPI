using BackendAPI.Modelo.UseCases;

public class CreateNewRoundUseCase
{
    private ICategoryRepository _categoryRepository;
    private ILetterRepository _letterRepository;

    public CreateNewRoundUseCase(ICategoryRepository categoryRepository, ILetterRepository letterRepository)
    {
        _categoryRepository = categoryRepository;
        _letterRepository = letterRepository;
    }

    public Round Execute(int roundNumber)
    {
        List<Category> categoryList = new FindRandomCategoryListUseCase(_categoryRepository).Execute();
        char roundLetter = new FindRandomLetterUseCase(_letterRepository).Execute();

        return new Round(categoryList,roundNumber, roundLetter);
    }
}