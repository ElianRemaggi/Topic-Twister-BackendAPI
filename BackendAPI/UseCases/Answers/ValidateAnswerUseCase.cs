using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ValidateAnswerUseCase
{
    private string _answer;
    private Category _category;

    public ValidateAnswerUseCase(string answer, Category category)
    {
        _answer = answer;
        _category = category;
    }

    public bool Execute()
    {
        if (_answer == String.Empty)
            return false;

        _answer = Char.ToUpper(_answer[0]) + _answer.Substring(1).ToLower();
        return _category.WordList.Contains(_answer);
    }

}

