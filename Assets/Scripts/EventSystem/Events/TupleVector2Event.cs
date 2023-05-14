using System;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace EventSystem.Events
{
    [CreateAssetMenu(menuName = "Events/TupleVector2Event")]
    public class TupleVector2Event : BaseGameEvent<Tuple<Vector2, Vector2>> { }
}