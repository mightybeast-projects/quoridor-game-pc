using System;
using EventSystem.Events;
using NaughtyAttributes;
using Quoridor.Core.GameLogic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class GameManager : MonoBehaviour {
    [Header("GameSettings")]
    [SerializeField] [Dropdown("_playerCountArray")] private int _playerCount;

    [Header("Events")]
    [SerializeField] private GameEvent _onGameStateChanged;
    private Game _game;
    private int[] _playerCountArray = new int[2] {2, 4};

    private void Start()
    {
        InitializeNewGame();

        _onGameStateChanged.Raise(_game);
    }

    public void MakeCurrentPlayerMove(PlayerMove playerMove)
    {
        TryToExecuteAction(() => _game.MakeCurrentPlayerMove(playerMove));
        Debug.Log("Player moved");
    }

    public void MakeCurrentPlayerPlaceWall(Tuple<Vector2, Vector2> wallPositions)
    {
        TryToExecuteAction(() => _game.MakeCurrentPlayerPlaceWall(wallPositions.Item1, wallPositions.Item2));
        Debug.Log("Wall placed");
    }

    public void TryToExecuteAction(Action Action)
    {
        try 
        {
            Action();
            _onGameStateChanged.Raise(_game);
        }
        catch (Exception e) { Debug.LogError(e.Message); }
    }

    private void InitializeNewGame()
    {
        _game = new Game();
        _game.AddNewPlayerPair();
        if(_playerCount == 4)
            _game.AddNewPlayerPair();
        _game.Start();
    } 
}