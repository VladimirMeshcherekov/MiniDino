using Enemy;
using EventBus.Signals;
using Markers;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerRun : MonoBehaviour
    {
        private EventBus.EventBus _eventBus;
        private bool _isPlayerDied = false;

        [Inject]
        private void Construct(EventBus.EventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<ChangePlayerStateSignal>(PlayerDied, 0);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Ground ground) && !_isPlayerDied)
            {
                _eventBus.Invoke(new ChangePlayerStateSignal(PlayerState.Run));
            }

            if (other.gameObject.TryGetComponent(out EnemyMove enemy))
            {
                _eventBus.Invoke(new ChangePlayerStateSignal(PlayerState.Die));
            }
        }

        private void PlayerDied(ChangePlayerStateSignal signal)
        {
            if (signal.State == PlayerState.Die)
            {
                _isPlayerDied = true;
            }
        }
    }
}