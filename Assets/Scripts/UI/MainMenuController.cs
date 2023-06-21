using System;

namespace Didenko.UI
{
  public class MainMenuController
  {
    public event Action PlayButtonCLicked;
  
    private readonly MainMenuView _mainMenu;

    public MainMenuController(MainMenuView mainMenu)
    {
      _mainMenu = mainMenu;

      SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
      _mainMenu.PlayButtonCLicked += () => PlayButtonCLicked?.Invoke();
    }
  }
}