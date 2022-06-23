using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ILetterRepository
{
    public char GetRandomLetter();
    public void LoadLetterRepository(string path);
}
