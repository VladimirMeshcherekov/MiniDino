using Player.Pause;
using Player.Pause.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    private EventBus.EventBus _eventBus;
    [FormerlySerializedAs("pauseManager")] [SerializeField] private CustomPauseManager customPauseManager;
    public override void InstallBindings()
    {
        Container.Bind<EventBus.EventBus>().FromNew().AsSingle().NonLazy();
        Container.Bind<IPauseHandler>().FromInstance(customPauseManager).AsSingle().NonLazy();
    }
}