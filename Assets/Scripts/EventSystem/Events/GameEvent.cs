using Quoridor.Core.GameLogic;
using UnityEngine;

namespace EventSystem.Events
{
    [CreateAssetMenu(menuName = "Events/GameEvent")]
    public class GameEvent : BaseGameEvent<Game> { }
}