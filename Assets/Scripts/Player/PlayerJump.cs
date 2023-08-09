using EventBus.Signals;
using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerJump : MonoBehaviour
    {
        private EventBus.EventBus _eventBus;
        private bool _canPlayerJump;
        
        [Inject]
        public void Construct(EventBus.EventBus eventBus, IAnimatePlayer animatePlayer)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<PlayerInputJumpSignal>(Jump, 0);
            _eventBus.Subscribe<ChangePlayerStateSignal>(PlayerStateChanged, 0);
        }
        
        private void Jump(PlayerInputJumpSignal signal)
        {
            if (_canPlayerJump == false) return;
            
            _eventBus.Invoke(new ChangePlayerStateSignal(PlayerState.Jump));
            _canPlayerJump = false;
        }

        private void PlayerStateChanged(ChangePlayerStateSignal newState)
        {
            if (newState.State == PlayerState.Run)
            {
                _canPlayerJump = true;
            }
        }
    }
}