using System;
using UnityEngine.Events;
using Vector2 = System.Numerics.Vector2;

namespace EventSystem.UnityEvents
{
    [System.Serializable] public class UnityTupleVector2Event : UnityEvent<Tuple<Vector2, Vector2>> { }
}