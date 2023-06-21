using Didenko.Infrastructure.States;
using Didenko.Services;
using Didenko.UI;

namespace Didenko.Infrastructure
{
  public class Game
  {
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingView loadingView)
    {
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container, loadingView);
    }
  }
}