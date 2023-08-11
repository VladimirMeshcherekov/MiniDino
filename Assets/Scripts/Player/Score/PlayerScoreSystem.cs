using System;
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

        [SerializeField] private string textBeforeCurrentScore;
        [SerializeField] private string textBeforeBestScore;

        private int _currentScore;
        private EventBus.EventBus _eventBus;
        private PlayerBestScore _playerBestScore;

        [Inject]
        private void Construct(EventBus.EventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<AddScoreToPlayerSignal>(AddScoreToPlayer, 0);
            _playerBestScore = new PlayerBestScore();
        }

        private void Awake()
        {
            ReloadCurrentScoreTextUI();
            ReloadBestScoreTextUI();
        }

        private void AddScoreToPlayer(AddScoreToPlayerSignal signal)
        {
            _currentScore += signal.ScoreValue;
            ReloadCurrentScoreTextUI();
            if (_currentScore > _playerBestScore.BestScoreValue)
            {
                _playerBestScore.SetNewBestScore(_currentScore);
                ReloadBestScoreTextUI();
            }
        }

        private void ReloadCurrentScoreTextUI()
        {
            currentScoreText.text = textBeforeCurrentScore + _currentScore.ToString();
        }

        private void ReloadBestScoreTextUI()
        {
            bestScoreText.text = textBeforeBestScore + _playerBestScore.BestScoreValue.ToString();
        }
    }
}