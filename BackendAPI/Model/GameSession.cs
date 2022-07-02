using System;
using System.Collections.Generic;

public class GameSession
{
    private int _sessionID;
    private Player _player1;
    private Player _player2;
    private Player _winner;
    private bool _isTie = false;
    private int _playerScore = 0;
    private int _opponentScore = 0;

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
    public int PlayerScore { get => _playerScore; set => _playerScore = value; }
    public int OpponentScore { get => _opponentScore; set => _opponentScore = value; }
    public Round CurrentRound { get => _currentRound; set => _currentRound = value; }
    public List<Round> MatchRounds { get => _matchRounds; set => _matchRounds = value; }
}
