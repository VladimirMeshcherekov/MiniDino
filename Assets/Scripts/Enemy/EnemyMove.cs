using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Vector2 _moveDirection;
        private Rigidbody2D _rigidbody2D;
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _moveDirection = Vector2.left;
        }

        // Update is called once per frame
        void Update()
        {
            _rigidbody2D.velocity = _moveDirection * speed;
        }
    }
}
