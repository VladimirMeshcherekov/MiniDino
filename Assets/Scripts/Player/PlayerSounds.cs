using EventBus.Signals;
using Player;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip playerLand;
    [SerializeField] private AudioClip playerDie;
    [SerializeField] private AudioClip playerJump;
    private AudioSource _audioSource;

    private EventBus.EventBus _eventBus;

    [Inject]
    private void Construct(EventBus.EventBus eventBus)
    {
        _eventBus = eventBus;
        _eventBus.Subscribe<ChangePlayerStateSignal>(PlayerStateChanged, 0);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void PlayerStateChanged(ChangePlayerStateSignal signal)
    {
        switch (signal.State)
        {
            case PlayerState.Die:
                _audioSource.PlayOneShot(playerDie);
                break;
            case PlayerState.Jump:
                _audioSource.PlayOneShot(playerJump);
                break;
            case PlayerState.Run:
                _audioSource.PlayOneShot(playerLand);
                break;
        }
    }
}