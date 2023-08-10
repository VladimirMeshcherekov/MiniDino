using System.Collections.Generic;
using EventBus.Signals;
using Player;
using Timers;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyMove> enemyPrefabs;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private int countdownToSpawnEnemy;
        
        private CustomPool<EnemyMove> _pool;
        private AsyncTimer _timerToSpawn;
        private EventBus.EventBus _eventBus;
        
        [Inject]
        private void Construct(EventBus.EventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        void Start()
        {
            _pool = new CustomPool<EnemyMove>(enemyPrefabs, 10, this.gameObject.transform);
            _timerToSpawn = new AsyncTimer(SetEnemy, countdownToSpawnEnemy, true);
            _timerToSpawn.StartTimer();
            _eventBus.Subscribe<ChangePlayerStateSignal>(PlayerStateChanged, 0);
            SetEnemy();
        }
        
        private void SetEnemy()
        {
            GameObject newEnemy = _pool.Get().gameObject;
            newEnemy.transform.position = spawnPoint.position;
        }

        private void PlayerStateChanged(ChangePlayerStateSignal signal)
        {
            if (signal.State == PlayerState.Die)
            {
                _timerToSpawn.StopTimer();
                foreach (var poolObject in _pool._objects)
                {
                    poolObject.DisableEnemyMove();
                }
            }
        }
        
    }
}
