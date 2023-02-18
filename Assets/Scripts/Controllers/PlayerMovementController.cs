using Data.UnityObject;
using UnityEngine;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        private PlayerMovementData _playerMovementData;
        private Vector3 _movementDirection;
        private float _moveSpeed;
        
        private void Awake()
        {
            _playerMovementData = Resources.Load<PlayerMovementData>("Data/PlayerMovementData");
            _moveSpeed = _playerMovementData.moveSpeed;
        }
        
        private void Update()
        {
            Movement();
            Rotation();
        }

        public void UpdateMovementDirection(Vector3 movementDirection) => _movementDirection = movementDirection;
        
        private void Movement()
        {
            transform.Translate(_movementDirection * _moveSpeed * Time.deltaTime, Space.World);
        }

        public void OnRunSkillUsed()
        {
            _moveSpeed = _playerMovementData.runSpeed;
        }

        public void OnRunSkillRevoked()
        {
            _moveSpeed = _playerMovementData.moveSpeed;
        }
        
        private void Rotation()
        {
            if (_movementDirection != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(_movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,
                    _playerMovementData.rotationSpeed * Time.deltaTime);
            }
        }
    }
}