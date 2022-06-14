using Newtonsoft.Json;

namespace BackendAPI.Modelo.Repository
{
    public class LetterRepository : ILetterRepository
    {
        public List<char> _charList;

        public LetterRepository()
        {
            LoadLetterRepository();
        }

        public char GetRandomLetter()
        {
            Random rand = new Random();
            return _charList.ElementAt(rand.Next(_charList.Count));
        }

        public void LoadLetterRepository()
        {
            string path = @"data\letters.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();

                char[] arrayResult = JsonConvert.DeserializeObject<char[]>(json);
                _charList = arrayResult.ToList();
            }
        }
    }
}
