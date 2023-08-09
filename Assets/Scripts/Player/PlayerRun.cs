using EventBus.Signals;
using Markers;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerRun : MonoBehaviour
    {
      private EventBus.EventBus _eventBus;
        
        [Inject]
        private void Construct(EventBus.EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Ground ground))
            {
              _eventBus.Invoke(new ChangePlayerStateSignal(PlayerState.Run));
            }
        }
    }
}