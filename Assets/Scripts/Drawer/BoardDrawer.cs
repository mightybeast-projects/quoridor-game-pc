using EventSystem.Events;
using Quoridor.Core;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;
using UnityEngine;

using Vector3 = UnityEngine.Vector3;

public class BoardDrawer : MonoBehaviour 
{
    public Game game { get; internal set; }
    public Vector3 currentPosition { get; internal set; }
    public int rowIndex { get; internal set; }
    public int colIndex { get; internal set; }

    [SerializeField] private GameEvent _onBoardDrawn;
    [SerializeField] private TileInstantiator _tileInstantiator;
    [SerializeField] private PlayerInstantiator _playerInstantiator;
    [SerializeField] private WallInstantiator _wallInstantiator;

    public void EraseBoard()
    {
        _tileInstantiator.DestroyTiles();
        _playerInstantiator.DestroyPlayers();
        _wallInstantiator.DestroyWalls();
    }

    public void DrawBoard(Game game)
    {
        this.game = game;
        currentPosition = Vector3.zero;

        for (rowIndex = 0; rowIndex < game.board.grid.GetLength(0); rowIndex++)
        {
            for (colIndex = 0; colIndex < game.board.grid.GetLength(1); colIndex++)
            {
                if (CurrentTileIsPlayer())
                    _playerInstantiator.InstantiatePlayer();
                if (CurrentTileIsWall())
                    _wallInstantiator.InstantiateWall();

                _tileInstantiator.InstantiateTiles();
            }

            UpdateCurrentPosition();
        }

        _onBoardDrawn.Raise(game);
    }

    private void UpdateCurrentPosition()
    {
        currentPosition = new Vector3(0, currentPosition.y, currentPosition.z);

        if (RowIndexIsEven())
            currentPosition += new Vector3(0, 0, 1);
        else
            currentPosition += new Vector3(0, 0, 0.5f);
    }

    private bool CurrentTileIsPlayer()
    {
        foreach (Player player in game.players)
            if (player.position.X == colIndex && player.position.Y == rowIndex)
                return true;
        return false;
    }

    private bool CurrentTileIsWall()
    {
        foreach (Wall wall in game.board.placedWalls)
            if (wall.startPosition.X == colIndex && wall.startPosition.Y == rowIndex)
                return true;
        return false;
    }

    private bool RowIndexIsEven()
    {
        return rowIndex % 2 == 0;
    }
}