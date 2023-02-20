using Controllers;
using Keys;
using Signals;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private PlayerPhysicController playerPhysicController;
        [SerializeField] private InvisibleSkillController invisibleSkillController;
        
        private void OnEnable() => SubscribeEvents();
        private void OnDisable() => UnSubscribeEvents();

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += OnInputTaken;
            InputSignals.Instance.onRunSkillUsed += OnRunSkillUsed;
            InputSignals.Instance.onRunSkillRevoked += OnRunSkillRevoked;
            InputSignals.Instance.onInteractSkillUsed += OnInteractSkillUsed;
            InputSignals.Instance.onInvisibleSkillUsed += OnInvisibleSkillUsed;
            // InputSignals.Instance.onDashSkillUsed += OnDashSkillUsed;
        }

        private void UnSubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= OnInputTaken;
            InputSignals.Instance.onRunSkillUsed -= OnRunSkillUsed;
            InputSignals.Instance.onRunSkillRevoked -= OnRunSkillRevoked;
            InputSignals.Instance.onInteractSkillUsed -= OnInteractSkillUsed;
            InputSignals.Instance.onInvisibleSkillUsed -= OnInvisibleSkillUsed;
            // InputSignals.Instance.onDashSkillUsed -= OnDashSkillUsed;
        }

        private void OnInputTaken(InputParams inputParams)
        {
            playerMovementController.UpdateMovementDirection(inputParams.MovementVector.normalized);
        }

        private void OnRunSkillUsed() => playerMovementController.OnRunSkillUsed();
        private void OnRunSkillRevoked() => playerMovementController.OnRunSkillRevoked();
        private void OnInteractSkillUsed() => playerPhysicController.Interact();
        private void OnInvisibleSkillUsed() => invisibleSkillController.UseSpell();
        // private void OnDashSkillUsed() => playerSkillController.OnDashSkillUsed();

        public Vector3 ReturnPosition() => transform.position;
    }
}