using UnityEngine;

public class TileInstantiator : MonoBehaviour 
{
    [SerializeField] private BoardDrawer _boardDrawer;
    [SerializeField] private Transform _tileGridTransform;
    [SerializeField] private GameObject _solidTilePrefab;
    [SerializeField] private GameObject _verticalVoidTilePrefab;
    [SerializeField] private GameObject _horizontalVoidTilePrefab;
    [SerializeField] private GameObject _centralVoidTilePrefab; 

    internal void InstantiateTiles()
    {
        if (RowIndexIsEven())
            DrawRowWithTiles(_solidTilePrefab, _verticalVoidTilePrefab);
        else
            DrawRowWithTiles(_horizontalVoidTilePrefab, _centralVoidTilePrefab);
    }

    internal void DestroyTiles()
    {
        for (int i = _tileGridTransform.childCount - 1; i >= 0 ; i--)
            DestroyImmediate(_tileGridTransform.transform.GetChild(i).gameObject);
    }

    private void DrawRowWithTiles(GameObject evenTile, GameObject oddTile)
    {
        if (ColIndexIsEven())
            InstantiateTile(evenTile, new Vector3(1, 0, 0));
        else
            InstantiateTile(oddTile, new Vector3(0.5f, 0, 0));
    }

    private void InstantiateTile(GameObject tilePrefab, Vector3 vectorToAdd)
    {
        GameObject tileGO = Instantiate(tilePrefab, _tileGridTransform);
        tileGO.transform.localPosition = _boardDrawer.currentPosition;
        
        tileGO.name = "Tile (" +  _boardDrawer.colIndex + ", " + _boardDrawer.rowIndex + ")";
        _boardDrawer.currentPosition += vectorToAdd;
    }

    private bool ColIndexIsEven()
    {
        return _boardDrawer.colIndex % 2 == 0;
    }

    private bool RowIndexIsEven()
    {
        return _boardDrawer.rowIndex % 2 == 0;
    }
}