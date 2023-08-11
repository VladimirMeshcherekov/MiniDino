using EventBus.Signals;
using UnityEngine;
using Zenject;

namespace Player.UI
{
    public class ShowGameOverElementsUI : MonoBehaviour
    {
        private EventBus.EventBus _eventBus;
        [SerializeField] private GameObject gameOverElements;
        [SerializeField] private GameObject pauseButton;

        [Inject]
        private void Construct(EventBus.EventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<ChangePlayerStateSignal>(PlayerStateChanged, 0);
        }

        private void Awake()
        {
            gameOverElements.SetActive(false);
        }

        private void PlayerStateChanged(ChangePlayerStateSignal signal)
        {
            if (signal.State == PlayerState.Die)
            {
                gameOverElements.SetActive(true);
                pauseButton.SetActive(false);
            }
        }
    }
}
