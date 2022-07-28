using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.UseCases
{
    class GetGameSessionById
    {
        private int id;

        public GetGameSessionById(int id)
        {
            this.id = id;
        }

        public GameSession Execute(IGameSessionRepository gameSessionRepository)
        {
            try
            {
                return gameSessionRepository.GetGameSessionByID(id);
            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
