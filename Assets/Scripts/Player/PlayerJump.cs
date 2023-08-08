using EventBus.Signals;
using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerJump : MonoBehaviour
    {
        EventBus.EventBus EventBus;
        private IAnimatePlayer _animatePlayer;

        [Inject]
        void Construct(EventBus.EventBus eventBus, IAnimatePlayer animatePlayer)
        {
            EventBus = eventBus;
            EventBus.Subscribe<PlayerJumpSignal>(Jump, 0);
            _animatePlayer = animatePlayer;
        }

        void Jump(PlayerJumpSignal signal)
        {
          _animatePlayer.SetJumpAnimation();
        }
    }
}