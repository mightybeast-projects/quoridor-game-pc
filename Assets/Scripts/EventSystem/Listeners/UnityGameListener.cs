using EventSystem.Events;
using EventSystem.UnityEvents;
using Quoridor.Core.GameLogic;

namespace EventSystem.Listeners
{
    public class UnityGameListener : BaseGameEventListener<Game, GameEvent, UnityGameEvent> { }
}