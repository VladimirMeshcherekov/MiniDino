using Zenject;

public class ServiceInstaller : MonoInstaller
{
    private EventBus.EventBus _eventBus;
    public override void InstallBindings()
    {
        Container.Bind<EventBus.EventBus>().FromNew().AsSingle().NonLazy();
    }
}