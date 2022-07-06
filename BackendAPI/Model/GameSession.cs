using System;
using System.Collections.Generic;

public class GameSession
{
    private int _sessionID;
    private Player _player1;
    private Player _player2;
    private Player _winner;
    private bool _isTie = false;
    private int _player1Score = 0;
    private int _player2Score = 0;

    private Round _currentRound;
    private List<Round> _matchRounds = new List<Round>();


    public GameSession(Player player1, Player player2,int sessionID)
    {
        _player1 = player1;
        _player2 = player2;
        _sessionID = sessionID;
    }

    public int SessionID { get => _sessionID; set => _sessionID = value; }
    public Player Player1 { get => _player1;}
    public Player Player2 { get => _player2;}
    public Player Winner { get => _winner; set => _winner = value; }
    public bool IsTie { get => _isTie; set => _isTie = value; }
    public int Player1Score { get => _player1Score; set => _player1Score = value; }
    public int Player2Score { get => _player2Score; set => _player2Score = value; }
    public Round CurrentRound { get => _currentRound; set => _currentRound = value; }
    public List<Round> MatchRounds { get => _matchRounds; set => _matchRounds = value; }
}
