using EventBus.Signals;
using UnityEngine;
using Zenject;

namespace Input
{
    public class InputSystem : MonoBehaviour
    {
        private EventBus.EventBus _eventBus;
        private PlayerInput _input;

        [Inject]
        void Construct(EventBus.EventBus eventBus)
        {
            _eventBus = eventBus;
            _input = new PlayerInput();
            _input.Enable();
            _input.PlayerJump.Jump.performed += ctx => Jump();
        }
        void Jump()
        {
            _eventBus.Invoke(new PlayerJumpSignal());
        }
    }
}