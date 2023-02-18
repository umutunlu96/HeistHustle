using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "PlayerMovementData", menuName = "ScriptableObj/PlayerMovementData", order = 0)]
    public class PlayerMovementData : ScriptableObject
    {
        public float moveSpeed;
        public float runSpeed;
        public float rotationSpeed;
    }
}