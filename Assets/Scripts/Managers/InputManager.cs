using Keys;
using Signals;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private float _horizontalInput;
        private float _verticalInput;
        
        private void Update()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");

            InputSignals.Instance.onInputTaken?.Invoke(new InputParams()
                {MovementVector = new Vector3(_horizontalInput, 0, _verticalInput)});
            
            if(Input.GetKeyDown(KeyCode.Space)) InputSignals.Instance.onInteractSkillUsed?.Invoke();
            if(Input.GetKeyDown(KeyCode.Q)) InputSignals.Instance.onInvisibleSkillUsed?.Invoke();
            if(Input.GetKeyDown(KeyCode.E)) InputSignals.Instance.onDashSkillUsed?.Invoke();
            if(Input.GetKeyDown(KeyCode.LeftShift)) InputSignals.Instance.onRunSkillUsed?.Invoke();
            if(Input.GetKeyUp(KeyCode.LeftShift)) InputSignals.Instance.onRunSkillRevoked?.Invoke();
        }
    }
}