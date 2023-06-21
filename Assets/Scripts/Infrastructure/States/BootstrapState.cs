using Didenko.Data;
using Didenko.Services;

namespace Didenko.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly AllServices _services;
    private readonly SceneLoader _sceneLoader;
  
    public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
    {
      _gameStateMachine = gameStateMachine;
      _services = services;
      _sceneLoader = sceneLoader;

      RegisterServices();
    }

    private void RegisterServices()
    {
      _services.RegisterSingle<IProgressService>(new ProgressService(new GameData(new KillData())));
      _services.RegisterSingle<IRandomService>(new RandomService());
      _services.RegisterSingle<IAssetLoaderService>(new AssetLoaderService());
      _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IAssetLoaderService>(), _services.Single<IProgressService>()));
    }

    public void Exit()
    {
    
    }

    public void Enter() => 
      _sceneLoader.Load("Bootstrap", OnLoaded);

    private void OnLoaded() => 
      _gameStateMachine.Enter<MainMenuState>();
  }
}