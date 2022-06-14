using Newtonsoft.Json;
using System.Collections.Generic;

public class PlayerData
{
    private int _winsAmount;
    private string _name;
    private List<PowerUp> _powerUps;

    public PlayerData(int winsAmount, string name, List<PowerUp> powerUps)
    {
        _winsAmount = winsAmount;
        _name = name;
        _powerUps = powerUps;
    }
    public PlayerData(int winsAmount, string name)
    {
        _winsAmount = winsAmount;
        _name = name;
    }

    [JsonConstructor]
    public PlayerData(int? winsAmount, string? name)
    {
        _winsAmount = (int)winsAmount;
        _name = name;
    }

    public int WinsAmount { get => _winsAmount; set => _winsAmount = value; }
    public string Name { get => _name;}
}