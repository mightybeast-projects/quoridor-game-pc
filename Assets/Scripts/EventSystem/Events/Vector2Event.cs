using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace EventSystem.Events
{
    [CreateAssetMenu(menuName = "Events/Vector2Event")]
    public class Vector2Event : BaseGameEvent<Vector2> { }
}