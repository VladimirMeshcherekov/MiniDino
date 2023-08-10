using EventBus.Signals;
using TMPro;
using UnityEngine;
using Zenject;

namespace Player.Score
{
    public class PlayerScoreSystem : MonoBehaviour
    {
       [SerializeField] private TMP_Text currentScoreText;
       [SerializeField] private TMP_Text bestScoreText;

       private int _currentScore;
       
       private EventBus.EventBus _eventBus;
       
       [Inject]
       private void Construct(EventBus.EventBus eventBus)
       {
           _eventBus = eventBus;
           _eventBus.Subscribe<AddScoreToPlayerSignal>(AddScoreToPlayer, 0);
       }

       private void AddScoreToPlayer(AddScoreToPlayerSignal signal)
       {
           _currentScore++;
           currentScoreText.text = _currentScore.ToString();
       }
    }
}