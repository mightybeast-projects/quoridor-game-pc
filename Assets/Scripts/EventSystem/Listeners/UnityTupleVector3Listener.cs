using System;
using EventSystem.Events;
using EventSystem.UnityEvents;
using UnityEngine;

namespace EventSystem.Listeners
{
    public class UnityTupleVector3Listener : BaseGameEventListener<Tuple<Vector3, Vector3>, TupleVector3Event, UnityTupleVector3Event> { }
}