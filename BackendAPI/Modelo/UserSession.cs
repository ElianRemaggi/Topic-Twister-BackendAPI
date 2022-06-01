using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserSession
{
    private Player _player;

    public UserSession(Player player)
    {
        _player = player;
    }

    public Player Player { get => _player; }
}
