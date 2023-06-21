using System;
using Opsive.UltimateCharacterController.UI;
using UnityEngine;

namespace Didenko.UI
{
  public class WeaponDisplay : MonoBehaviour
  {
    public UIFollow UIFollow;
    public GunDisplayView GunDisplayView;
    public AttributeMonitor AttributeMonitor;

    public void Init(GameObject player)
    {
      UIFollow.Init(player.transform);
      GunDisplayView.Character = player;
      AttributeMonitor.Character = player;
    }
  }
}
