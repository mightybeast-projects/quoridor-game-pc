using EventSystem.Events;
using EventSystem.UnityEvents;
using Quoridor.Core.GameLogic;

namespace EventSystem.Listeners
{
    public class UnityPlayerMoveListener : BaseGameEventListener<PlayerMove, PlayerMoveEvent, UnityPlayerMoveEvent> { }
}