using Player.Interfaces;
using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    private EventBus.EventBus _eventBus;

    [SerializeField] private PlayerAnimations _animatePlayer;
    public override void InstallBindings()
    {
        Container.Bind<EventBus.EventBus>().FromNew().AsSingle().NonLazy();
        Container.Bind<IAnimatePlayer>().FromInstance(_animatePlayer).AsSingle().NonLazy();
    }
}