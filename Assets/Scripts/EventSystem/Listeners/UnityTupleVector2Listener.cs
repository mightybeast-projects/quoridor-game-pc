using System.Numerics;
using System;
using EventSystem.Events;
using EventSystem.UnityEvents;
using Vector2 = System.Numerics.Vector2;

namespace EventSystem.Listeners
{
    public class UnityTupleVector2Listener : BaseGameEventListener<Tuple<Vector2, Vector2>, TupleVector2Event, UnityTupleVector2Event> { }
}