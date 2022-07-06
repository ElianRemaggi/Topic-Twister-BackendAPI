public class Answer
{
    private string _playerAnswer;
    private bool _correct;

    public Answer(string playerAnswer, bool correct)
    {
        _playerAnswer = playerAnswer;
        _correct = correct;
    }

    public string PlayerAnswer { get => _playerAnswer; set => _playerAnswer = value; }
    public bool Correct { get => _correct; set => _correct = value; }
}
