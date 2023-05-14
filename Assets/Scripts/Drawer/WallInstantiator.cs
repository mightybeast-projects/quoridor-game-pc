using Quoridor.Core;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class WallInstantiator : MonoBehaviour 
{
    [SerializeField] private BoardDrawer _boardDrawer;
    [SerializeField] private Transform _wallsTransform;
    [SerializeField] private GameObject _wallPrefab;
    
    private Vector2 _diff;

    internal void DestroyWalls()
    {
        for (int i = _wallsTransform.childCount - 1; i >= 0 ; i--)
            DestroyImmediate(_wallsTransform.transform.GetChild(i).gameObject);
    }

    internal void InstantiateWall()
    {
        GameObject wallGO = Instantiate(_wallPrefab, _wallsTransform);
        wallGO.transform.localPosition = _boardDrawer.currentPosition;

        foreach (Wall wall in _boardDrawer.game.board.placedWalls)
            if (CurrentPositionIsWallStart(wall))
                AdjustWallPosition(wallGO, wall);
    }

    private void AdjustWallPosition(GameObject wallGO, Wall wall)
    {
        _diff = wall.endPosition - wall.startPosition;

        if (_diff == new Vector2(-2, 0))
            wallGO.transform.localPosition += new Vector3(-1.5f, 0, 0);
        else if (_diff == new Vector2(0, -2))
            wallGO.transform.Rotate(0, 90, 0);
        else if (_diff == new Vector2(0, 2))
        {
            wallGO.transform.Rotate(0, 90, 0);
            wallGO.transform.localPosition += new Vector3(0, 0, 1.5f);
        }
    }

    private bool CurrentPositionIsWallStart(Wall wall)
    {
        return wall.startPosition.X == _boardDrawer.colIndex && wall.startPosition.Y == _boardDrawer.rowIndex;
    }
}