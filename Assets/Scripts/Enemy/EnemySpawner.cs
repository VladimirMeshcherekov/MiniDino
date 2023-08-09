using System.Collections.Generic;
using Timers;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyMove> enemyPrefabs;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private int countdownToSpawnEnemy;
        
        private CustomPool<EnemyMove> _pool;
        private AsyncTimer _timerToSpawn;
        
        void Start()
        {
            _pool = new CustomPool<EnemyMove>(enemyPrefabs, 10, this.gameObject.transform);
            _timerToSpawn = new AsyncTimer(SetEnemy, countdownToSpawnEnemy, true);
            _timerToSpawn.StartTimer();
        }
        
        private void SetEnemy()
        {
            GameObject newEnemy = _pool.Get().gameObject;
            newEnemy.transform.position = spawnPoint.position;
        }
    }
}
