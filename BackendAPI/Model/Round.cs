using System.Collections.Generic;

public class Round
{
    private List<Category> _categories;

    private List<Answer> _player1Answers = new List<Answer>();
    private List<Answer> _player2Answers = new List<Answer>();

    private int _score;
    private char _roundLetter;
    private int _roundNumber;

    public Round(List<Category> categories, int roundNumber, char roundLetter)
    {
        _categories = categories;
        _roundNumber = roundNumber;
        _roundLetter = roundLetter;
    }

    public List<Category> Categories { get => _categories; set => _categories = value; }
    public int Score { get => _score; set => _score = value; }
    public char RoundLetter { get => _roundLetter; set => _roundLetter = value; }
    public int RoundNumber { get => _roundNumber; set => _roundNumber = value; }
    public List<Answer> Player1Answers { get => _player1Answers; set => _player1Answers = value; }
    public List<Answer> Player2Answers { get => _player2Answers; set => _player2Answers = value; }
}
