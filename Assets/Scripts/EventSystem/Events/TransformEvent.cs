using UnityEngine;

namespace EventSystem.Events
{
    [CreateAssetMenu(menuName = "Events/TransformEvent")]
    public class TransformEvent : BaseGameEvent<Transform> { }
}