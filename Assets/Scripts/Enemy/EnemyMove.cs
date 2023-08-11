using Player.Pause.Interfaces;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class EnemyMove : MonoBehaviour, ICustomPauseBehavior
    {
        [SerializeField] private float speed;
        
        private Vector2 _moveDirection;
        private Rigidbody2D _rigidbody2D;
        private float _minimumCameraViewPositionX;
        private float _currentSpeed;
      
        private void Start()
        {
            _currentSpeed = speed;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _moveDirection = Vector2.left;
            _minimumCameraViewPositionX = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        }

        public void FixedUpdate()
        {
            _rigidbody2D.velocity = _moveDirection * _currentSpeed;
            if (_minimumCameraViewPositionX >= transform.position.x + transform.localScale.x)
            {
                ResetObject();
            }
        }

        private void ResetObject()
        {
            gameObject.SetActive(false);
        }

        public void DisableEnemyMove()
        {
            _currentSpeed = 0;
        }

        public void SetPaused(bool isPaused)
        {
            switch (isPaused)
            {
                case true:
                    _currentSpeed = 0;
                    break;
                case false:
                    _currentSpeed = speed;
                    break;
            }
        }
    }
}