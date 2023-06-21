using UnityEngine;

namespace Didenko.Infrastructure
{
  public interface IUIFactory : IService
  {
    GameObject CreateMainMenu();
    GameObject CreateHUD(GameObject player);
    GameObject CreateWeaponDisplay(GameObject player);
    GameObject CreateGameOver();
    void CreateUIRoot();
  }
}