using Markers;
using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerRun : MonoBehaviour
    {
        private IAnimatePlayer _animatePlayer;
        
        [Inject]
        private void Construct(IAnimatePlayer animatePlayer)
        {
            _animatePlayer = animatePlayer;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Ground ground))
            {
                _animatePlayer.SetRunAnimation();
            }
        }
    }
}