using System;
using UnityEngine;
using UnityEngine.Events;

namespace EventSystem.UnityEvents
{
    [System.Serializable] public class UnityTupleVector3Event : UnityEvent<Tuple<Vector3, Vector3>> { }
}