using UnityEngine;

namespace AsteroidBashers
{
    public class Rotation : MonoBehaviour
    {

        public Vector3 rotateVector = Vector3.zero;
        public enum spaceEnum { Local, World };
        public spaceEnum rotateSpace;

        void Update()
        {
            if (rotateSpace == spaceEnum.Local)
                transform.Rotate(rotateVector * Time.deltaTime);
            if (rotateSpace == spaceEnum.World)
                transform.Rotate(rotateVector * Time.deltaTime, Space.World);
        }
    }
}