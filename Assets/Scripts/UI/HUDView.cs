using Opsive.UltimateCharacterController.UI;
using UnityEngine;

namespace Didenko.UI
{
  public class HUDView : MonoBehaviour, IView
  {
    public HealthFlashMonitor HealthFlashMonitor;
    public CrosshairsMonitor CrosshairsMonitor;
  
    public void Init(GameObject player)
    {
      CrosshairsMonitor.Character = player;
      HealthFlashMonitor.Character = player;
    }
  
    public void Show()
    {
      gameObject.SetActive(true);
    }

    public void Hide()
    {
      gameObject.SetActive(false);
    }
  }
}
