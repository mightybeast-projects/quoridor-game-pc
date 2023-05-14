using Quoridor.Core.GameLogic;
using UnityEngine;

namespace EventSystem.Events
{
    [CreateAssetMenu(menuName = "Events/PlayerMoveEvent")]
    public class PlayerMoveEvent : BaseGameEvent<PlayerMove> { }
}