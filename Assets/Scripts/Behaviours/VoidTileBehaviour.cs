using EventSystem.Events;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Behaviours
{
    public class VoidTileBehaviour : MonoBehaviour 
    {
        [SerializeField] private Vector2Event _onVoidTilePressed;

        public void SelectThisTile()
        {
            string nameStr = gameObject.transform.parent.name;
            string[] nameArray = nameStr.Split('(')[1].Split(')')[0].Split(',');
            Debug.Log(nameArray[0] + " " + nameArray[1]);
            _onVoidTilePressed.Raise(new Vector2(float.Parse(nameArray[0]), float.Parse(nameArray[1])));
        }
    }
}