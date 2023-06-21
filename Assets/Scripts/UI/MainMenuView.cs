using System;
using UnityEngine;
using UnityEngine.UI;

namespace Didenko.UI
{
  public class MainMenuView : MonoBehaviour, IView
  {
    public event Action PlayButtonCLicked;

    public Button PlayButton;
  
    public void Show()
    {
      AddListeners();
    
      gameObject.SetActive(true);
    }

    public void Hide()
    {
      RemoveListeners();
      gameObject.SetActive(false);
    }

    private void RemoveListeners() => 
      PlayButton.onClick.RemoveAllListeners();

    private void AddListeners() => 
      PlayButton.onClick.AddListener(() => PlayButtonCLicked?.Invoke());
  }
}