using Interface;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysicController : MonoBehaviour
    {
        private IInteractable _Iinteractable;

        public void Interact()
        {
            if(_Iinteractable != null) _Iinteractable.Interact();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Interactable"))
            {
                _Iinteractable = other.GetComponent<IInteractable>();
            }
        }
    }
}