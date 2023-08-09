using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Vector2 _moveDirection;
        private Rigidbody2D _rigidbody2D;
        private float _minimumCameraViewPositionX;

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _moveDirection = Vector2.left;
            _minimumCameraViewPositionX = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        }

        void Update()
        {
            _rigidbody2D.velocity = _moveDirection * speed;
            if (_minimumCameraViewPositionX >= transform.position.x + transform.localScale.x)
            {
                ResetObject();
            }
        }

        private void ResetObject()
        {
            gameObject.SetActive(false);
        }
    }
}