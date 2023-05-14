using UnityEngine;

namespace EventSystem.Events
{
    [CreateAssetMenu(menuName = "Events/StringEvent")]
    public class StringEvent : BaseGameEvent<string> { }
}