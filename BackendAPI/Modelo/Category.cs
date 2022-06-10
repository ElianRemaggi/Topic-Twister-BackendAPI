using System.Collections.Generic;

public class Category
{
    private int _categoryID;
    private string _categoryName;
    private List<string> _wordList;

    public Category(int categoryID, string categoryName, List<string> wordList)
    {
        _categoryID = categoryID;
        _categoryName = categoryName;
        _wordList = wordList;
    }

    public string CategoryName { get => _categoryName;}
    public List<string> WordList { get => _wordList;}
    public int CategoryID { get => _categoryID; set => _categoryID = value; }
}
