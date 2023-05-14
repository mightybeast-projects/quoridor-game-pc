using UnityEngine;
using UnityEngine.Events;

public class ObjectButton3D : MonoBehaviour {
    [SerializeField] private UnityEvent _event;

    private void OnMouseDown() {
        _event.Invoke();
    }
}