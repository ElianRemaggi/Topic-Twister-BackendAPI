using Newtonsoft.Json;
using System.Collections.Generic;

[System.Serializable]
public class Player
{
    private string _userID;
    private bool _lookingForMatch;
    private PlayerData _playerData;

    public Player(string userID, PlayerData playerData)
    {
        _userID = userID;
        _playerData = playerData;
    }

    public string UserID { get => _userID; }
    public bool LookingForMatch { get => _lookingForMatch; set => _lookingForMatch = value; }
    public PlayerData PlayerData { get => _playerData; set => _playerData = value; }

    public void AddVictory()
    {
        _playerData.WinsAmount++;
    }

    public void SetVictories(int victories)
    {
        _playerData.WinsAmount = victories;
    }

    public int GetVictories()
    {
        return _playerData.WinsAmount;
    }
}
