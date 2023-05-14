using Behaviours;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;
using UnityEngine;

public class PlayerInstantiator : MonoBehaviour 
{
    [SerializeField] private BoardDrawer _boardDrawer;
    [SerializeField] private Transform _playersGridTransform;
    [SerializeField] private GameObject _playerPrefab;

    private Game _game;

    internal void DestroyPlayers()
    {
        for (int i = _playersGridTransform.childCount - 1; i >= 0 ; i--)
            DestroyImmediate(_playersGridTransform.transform.GetChild(i).gameObject);
    }

    internal void InstantiatePlayer()
    {
        _game = _boardDrawer.game;

        GameObject playerGO = Instantiate(_playerPrefab, _playersGridTransform);
        playerGO.transform.localPosition = _boardDrawer.currentPosition;

        foreach (Player player in _game.players)
            if (player.position.X == _boardDrawer.colIndex && player.position.Y == _boardDrawer.rowIndex)
                UpdatePlayerInfo(playerGO, player);
    }

    private void UpdatePlayerInfo(GameObject playerGO, Player player)
    {
        playerGO.name = "Player " + (_game.players.IndexOf(player) + 1);
        if (player == _game.currentPlayer)
            playerGO.GetComponent<FloatBehaviour>().enabled = true;
        else
            playerGO.GetComponent<FloatBehaviour>().enabled = false;
    }
}