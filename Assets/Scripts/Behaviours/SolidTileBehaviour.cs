using EventSystem.Events;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Behaviours
{
    public class SolidTileBehaviour : MonoBehaviour 
    {
        [SerializeField] private Vector2Event _onSolidTilePressed;

        public void SelectThisSolidTile()
        {
            string nameStr = gameObject.name;
            string[] nameArray = nameStr.Split('(')[1].Split(')')[0].Split(',');
            _onSolidTilePressed.Raise(new Vector2(float.Parse(nameArray[0]), float.Parse(nameArray[1])));
        }
    }
}