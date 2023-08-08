using EventBus.Signals;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerJump : MonoBehaviour
    {
        [Inject] EventBus.EventBus EventBus;
        void Start()
        {
            EventBus.Subscribe<PlayerJumpSignal>(Jump, 0);
        }
        
        void Jump(PlayerJumpSignal signal)
        {
            print("jump");
        }
    }
}
