using System;
using System.Collections.Generic;
using Didenko.Enemy;
using Didenko.Services;
using Didenko.UI;
using Didenko.Utils;
using Opsive.Shared.Input;
using UnityEngine;

namespace Didenko.Infrastructure.States
{
  public class GameSetupState : IState
  {
    private readonly string Gameplay = "Gameplay";
  
    private readonly GameStateMachine _gameStateMachine;
    private readonly IUIFactory _uiFactory;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingView _loadingView;
    private readonly IRandomService _randomService;
    private readonly IProgressService _progressService;
    
    private CharactersHolder _charactersHolder;
    private Player _player;
    private UnityInput _unityInput;
    private List<EnemyController> _enemies;

    public GameSetupState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services, LoadingView loadingView)
    {
      _gameStateMachine = gameStateMachine;
      _uiFactory = services.Single<IUIFactory>();
      _sceneLoader = sceneLoader;
      _loadingView = loadingView;
      _randomService = services.Single<IRandomService>();
      _progressService = services.Single<IProgressService>();
    }
  
    public void Exit()
    {
    
    }

    public void Enter()
    {
      _loadingView.Show();
      _sceneLoader.Load(Gameplay, OnLoaded);
    }

    private void OnLoaded()
    {
      _loadingView.Hide();
      
      _charactersHolder = GameObject.FindGameObjectWithTag(Tags.CharactersHolder).GetComponent<CharactersHolder>();

      _progressService.GameData.KillData.KillCount = 0;
      
      SetupPlayer();
      SetupEnemies();
      SetupUI();
    }

    private void SetupPlayer()
    {
      _player = _charactersHolder.Player;
      _unityInput = _player.GetComponent<UnityInput>();
      
      _player.Died += OnPlayerDeath;
    }

    private void SetupEnemies()
    {
      _enemies = _charactersHolder.Enemies;
      foreach (EnemyController enemyController in _enemies)
      {
        enemyController.Init(_player);
        enemyController.EnemyDied += OnEnemyDied;
      }
    }

    private void OnEnemyDied() => 
      _progressService.GameData.KillData.KillCount += 1;

    private void SetupUI()
    {
      _uiFactory.CreateUIRoot();
      //_uiFactory.CreateHUD(_player.gameObject).GetComponent<IView>().Show();
      _uiFactory.CreateWeaponDisplay(_player.gameObject);
    }

    private void OnPlayerDeath()
    {
      _unityInput.DisableCursor = false;
      
      GameOverView gameOverView = _uiFactory.CreateGameOver().GetComponent<GameOverView>();
      gameOverView.Show();
      
      gameOverView.RestartCLicked += RestartGame;
      gameOverView.MainMenuCLicked += () => _gameStateMachine.Enter<MainMenuState>();
    }

    private void RestartGame()
    {
      _sceneLoader.Load("Loading", () => _gameStateMachine.Enter<GameSetupState>());
    }
  }
}