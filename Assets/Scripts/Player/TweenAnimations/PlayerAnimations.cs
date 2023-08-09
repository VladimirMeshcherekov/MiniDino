using DG.Tweening;
using EventBus.Signals;
using Player;
using Player.Interfaces;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour, IAnimatePlayer
{
    [SerializeField] private Transform endJumpPoint;
    [SerializeField] private int jumpPower;
    [SerializeField] private float jumpDuration;
    [SerializeField] private float fallAcceleration;
    [Space] [SerializeField] private AnimationClip playerJump, playerRun, playerDie;

    private const int JumpNum = 1;
    private Animator _playerAnimator;
    private EventBus.EventBus _eventBus;

    [Inject]
    private void Construct(EventBus.EventBus eventBus)
    {
        _eventBus = eventBus;
        _eventBus.Subscribe<ChangePlayerStateSignal>(ChangePlayerAnimation, 0);
    }

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void ChangePlayerAnimation(ChangePlayerStateSignal newState)
    {
        switch (newState.State)
        {
            case PlayerState.Die:
                SetDieAnimation();
                break;
            case PlayerState.Jump:
                SetJumpAnimation();
                print(123);
                break;
            case PlayerState.Run:
                SetRunAnimation();
                break;
        }
    }


    public void SetJumpAnimation()
    {
        _playerAnimator.Play(playerJump.name);
        Vector3 positionBeforeJump = transform.position;
        transform.DOJump(endJumpPoint.transform.position, jumpPower, JumpNum, jumpDuration);
        transform.DOJump(positionBeforeJump, jumpPower, JumpNum, jumpDuration / fallAcceleration)
            .SetDelay(jumpDuration);
    }

    public void SetDieAnimation()
    {
        _playerAnimator.Play(playerDie.name);
    }

    public void SetRunAnimation()
    {
        _playerAnimator.Play(playerRun.name);
    }
}