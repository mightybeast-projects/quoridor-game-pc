using System;
using UnityEngine;

namespace EventSystem.Events
{
    [CreateAssetMenu(menuName = "Events/TupleVector3Event")]
    public class TupleVector3Event : BaseGameEvent<Tuple<Vector3, Vector3>> { }
}