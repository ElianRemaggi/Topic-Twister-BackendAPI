using BackendAPI.Modelo.Repository;
using BackendAPI.Modelo.UseCases;

namespace BackendAPI.Service
{
    public class PathProvider
    {
        public static string GetLetterJsonPath()
        {
            return @"data\letters.json";
        }
        public static string GetCategoryJsonPath()
        {
            return @"data\categorys.json";
        }
        public static string GetPlayersJsonPath()
        {
            return @"data\players.json";
        }
    }
}
