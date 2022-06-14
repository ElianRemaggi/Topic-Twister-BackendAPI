using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IUserSessionRepository
{
    public UserSession CreateUserSession(Player player);
    public UserSession GetCurrentUserSession();
}

