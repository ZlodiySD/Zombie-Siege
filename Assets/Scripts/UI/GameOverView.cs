using System;
using Didenko.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Didenko.UI
{
  public class GameOverView : MonoBehaviour, IView
  {
    public event Action MainMenuCLicked;
    public event Action RestartCLicked;

    public Button MainMenu;
    public Button Restart;

    public TextMeshProUGUI Score;
    private GameData _gameData;

    public void Init(GameData gameData)
    {
      _gameData = gameData;

      AddListeners();
    }

    private void AddListeners()
    {
      MainMenu.onClick.AddListener(() => MainMenuCLicked?.Invoke());
      Restart.onClick.AddListener(() => RestartCLicked?.Invoke());
    }

    public void Show()
    {
      gameObject.SetActive(true);

      Score.text = _gameData.KillData.KillCount.ToString();
    }

    public void Hide()
    {
      gameObject.SetActive(false);
    }
  }
}
