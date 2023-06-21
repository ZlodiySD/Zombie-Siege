using Didenko.Services;
using Didenko.UI;
using UnityEngine;

namespace Didenko.Infrastructure
{
  public class UIFactory : IUIFactory
  {
    private const string UIRootPath = "UI/UIRoot";
    private const string MainMenuAssetPath = "UI/MainMenu";
    private const string HUDAssetPath = "UI/HUD";
    private const string WeaponDisplayAssetPath = "UI/WeaponDisplay";
    private const string GameOverAssetPath = "UI/GameOver";
  
    private readonly IAssetLoaderService _assetLoader;
    private IProgressService _progressService;
    
    private Transform _uiRoot;

    public UIFactory(IAssetLoaderService assetLoader, IProgressService progressService)
    {
      _progressService = progressService;
      _assetLoader = assetLoader;
    }

    public void CreateUIRoot() => 
      _uiRoot = _assetLoader.InstantiateAsset(UIRootPath).transform;

    public GameObject CreateMainMenu() => 
      _assetLoader.InstantiateAsset(MainMenuAssetPath, _uiRoot);

    public GameObject CreateHUD(GameObject player)
    {
      HUDView hud = _assetLoader.InstantiateAsset(HUDAssetPath, _uiRoot).GetComponent<HUDView>();
      hud.Init(player);
    
      return hud.gameObject;
    }

    public GameObject CreateWeaponDisplay(GameObject player)
    {
      WeaponDisplay display = _assetLoader.InstantiateAsset(WeaponDisplayAssetPath).GetComponent<WeaponDisplay>();
      display.Init(player);
    
      return display.gameObject;
    }

    public GameObject CreateGameOver()
    {
      GameOverView hud = _assetLoader.InstantiateAsset(GameOverAssetPath, _uiRoot).GetComponent<GameOverView>();
      hud.Init(_progressService.GameData);
    
      return hud.gameObject;
    }
  }
}