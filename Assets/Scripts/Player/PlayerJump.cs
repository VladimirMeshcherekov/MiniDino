using EventBus.Signals;
using Player.Pause;
using Player.Pause.Interfaces;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerJump : MonoBehaviour, ICustomPauseBehavior
    {
        private EventBus.EventBus _eventBus;
        private bool _stayPlayerOnGround;
        private IPauseHandler _customPauseManager;
        private bool _isPaused = false;

        [Inject]
        public void Construct(EventBus.EventBus eventBus, IPauseHandler customPauseManager)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<PlayerInputJumpSignal>(Jump, 0);
            _eventBus.Subscribe<ChangePlayerStateSignal>(PlayerStateChanged, 0);
            
            _customPauseManager = customPauseManager;
            _customPauseManager.AddPausedBehaviorObject(this);
        }
        
        private void Jump(PlayerInputJumpSignal signal)
        {
            if (_stayPlayerOnGround == false || _isPaused == true) return;
            
            _eventBus.Invoke(new ChangePlayerStateSignal(PlayerState.Jump));
            _stayPlayerOnGround = false;
        }

        private void PlayerStateChanged(ChangePlayerStateSignal newState)
        {
            if (newState.State == PlayerState.Run)
            {
                _stayPlayerOnGround = true;
            }
        }
        
        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}