using System.Numerics;
using System;
using EventSystem.Events;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

public class WallPlacementHandler : MonoBehaviour 
{
    [SerializeField] private TupleVector2Event _onWallCoordinatesInitialized;

    private Vector2 _wallStartPosition;

    public void SetWallCoordinatesAndRaiseEvent(Vector2 voidTilePosition)
    {
        if (_wallStartPosition == Vector2.Zero)
            _wallStartPosition = voidTilePosition;
        else
        {
            _onWallCoordinatesInitialized.Raise(new Tuple<Vector2, Vector2>(_wallStartPosition, voidTilePosition));
            _wallStartPosition = Vector2.Zero;
        }
    }
}