using Quoridor.Core.GameLogic;
using UnityEngine.Events;

namespace EventSystem.UnityEvents
{
    [System.Serializable] public class UnityPlayerMoveEvent : UnityEvent<PlayerMove> { }
}