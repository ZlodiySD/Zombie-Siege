using Didenko.Infrastructure.States;
using Didenko.UI;
using UnityEngine;

namespace Didenko.Infrastructure
{
  public class Bootstrapper : MonoBehaviour, ICoroutineRunner
  {
    public LoadingView LoadingView;
    
    private Game _game;

    private void Awake()
    {
      _game = new Game(this, LoadingView);
      _game.StateMachine.Enter<BootstrapState>();

      DontDestroyOnLoad(this);
    }
  }
}