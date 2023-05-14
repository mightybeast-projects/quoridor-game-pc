using System.Numerics;
using EventSystem.Events;
using EventSystem.UnityEvents;
using UnityEngine;

namespace EventSystem.Listeners
{
    public class UnityTransformListener : BaseGameEventListener<Transform, TransformEvent, UnityTransformEvent> { }
}