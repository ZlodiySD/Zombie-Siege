using Didenko.UI;

namespace Didenko.Infrastructure.States
{
  public class MainMenuState : IState
  {
    private readonly string MainMenu = "MainMenu";
  
    private readonly SceneLoader _sceneLoader;
    private readonly IUIFactory _uiFactory;
    private readonly LoadingView _loadingView;
    private readonly GameStateMachine _gameStateMachine;

    public MainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IUIFactory uiFactory, LoadingView loadingView)
    {
      _sceneLoader = sceneLoader;
      _uiFactory = uiFactory;
      _loadingView = loadingView;
      _gameStateMachine = gameStateMachine;
    }
  
    public void Exit()
    {
    
    }

    public void Enter()
    {
      _loadingView.Show();
      _sceneLoader.Load(MainMenu, OnLoaded);
    }

    private void OnLoaded()
    {
      _loadingView.Hide();
      SetupUI();
    }

    private void SetupUI()
    {
      _uiFactory.CreateUIRoot();

      MainMenuView mainMenuView = _uiFactory.CreateMainMenu().GetComponent<MainMenuView>();
      MainMenuController mainMenuController = new MainMenuController(mainMenuView);

      mainMenuView.Show();
      mainMenuController.PlayButtonCLicked += PlayGame;
    }

    private void PlayGame() => 
      _gameStateMachine.Enter<GameSetupState>();
  }
}