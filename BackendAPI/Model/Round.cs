using System.Collections.Generic;

public class Round
{
    private List<Category> _categories;
    private int _score;
    private char _roundLetter;
    private int _roundNumber;

    public Round(List<Category> categories, int roundNumber) //Esto hay que eliminarlo
    {
        _categories = categories;
        _roundNumber = roundNumber;
    }

    public List<Category> Categories { get => _categories; set => _categories = value; }
    public int Score { get => _score; set => _score = value; }
    public char RoundLetter { get => _roundLetter; set => _roundLetter = value; }
    public int RoundNumber { get => _roundNumber; set => _roundNumber = value; }
}
