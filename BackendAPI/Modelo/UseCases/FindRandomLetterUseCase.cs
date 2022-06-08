namespace BackendAPI.Modelo.UseCases
{
    public class FindRandomLetterUseCase
    {
        private ILetterRepository _letterRepository;

        public FindRandomLetterUseCase(ILetterRepository letterRepository)
        {
            _letterRepository = letterRepository;
        }

        public char Execute()
        {
            return _letterRepository.GetRandomLetter();
        }
    }
}
