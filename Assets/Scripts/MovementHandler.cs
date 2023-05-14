using EventSystem.Events;
using Quoridor.Core.GameLogic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class MovementHandler : MonoBehaviour 
{
    [SerializeField] private PlayerMoveEvent _onPlayerMoveSelected;

    private Game _game;
    private Vector2 _moveVector;
    private PlayerMove _playerMove;

    public void AssignGame(Game game)
    {
        _game = game;
    }

    public void ChoosePlayerMove(Vector2 positionToMove)
    {
        Vector2 playerPosition = _game.currentPlayer.position;
        _moveVector = 
            new Vector2((positionToMove.X - playerPosition.X) / 2, (positionToMove.Y - playerPosition.Y) / 2);

        RaiseAppropriateMoveEvent();
    }

    private void RaiseAppropriateMoveEvent()
    {
        if(topRightMove())
            _playerMove = PlayerMove.MOVE_DIAGONALLY_TOP_RIGHT;
        else if(topLeftMove())
             _playerMove = PlayerMove.MOVE_DIAGONALLY_TOP_LEFT;
        else if(bottomRightMove())
             _playerMove = PlayerMove.MOVE_DIAGONALLY_BOTOM_RIGHT;
        else if(bottomLeftMove())
             _playerMove = PlayerMove.MOVE_DIAGONALLY_BOTTOM_LEFT;
        else if(rightMove()) 
             _playerMove = PlayerMove.MOVE_RIGHT;
        else if(leftMove()) 
             _playerMove = PlayerMove.MOVE_LEFT;
        else if(upMove())
             _playerMove = PlayerMove.MOVE_UP;
        else if(bottomMove()) 
             _playerMove = PlayerMove.MOVE_DOWN;

        _onPlayerMoveSelected.Raise(_playerMove);
    }

    private bool topRightMove() {
        return _moveVector.X > 0 && _moveVector.Y > 0;
    }

    private bool topLeftMove() {
        return _moveVector.X < 0 && _moveVector.Y > 0;
    }

    private bool bottomRightMove() {
        return _moveVector.X > 0 && _moveVector.Y < 0;
    }

    private bool bottomLeftMove() {
        return _moveVector.X < 0 && _moveVector.Y < 0;
    }

    private bool rightMove()
    {
        return _moveVector.X > 0;
    }

    private bool leftMove()
    {
        return _moveVector.X < 0;
    }

    private bool upMove()
    {
        return _moveVector.Y > 0;
    }

    private bool bottomMove()
    {
        return _moveVector.Y < 0;
    }
}