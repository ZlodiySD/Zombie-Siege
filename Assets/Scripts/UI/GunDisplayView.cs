using Opsive.Shared.Inventory;
using Opsive.UltimateCharacterController.Items;
using Opsive.UltimateCharacterController.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Didenko.UI
{
  public class GunDisplayView : ItemMonitor
  {
    public TextMeshProUGUI TotalAmount;
    public TextMeshProUGUI CurrentAmount;

    public Image GunIcon;

    public BulletCounterView BulletCounterView;

    protected override void OnAttachCharacter(GameObject character)
    {
      base.OnAttachCharacter(character);
    
      for (int i = 0; i < m_CharacterInventory.SlotCount; ++i) {
        var item = m_CharacterInventory.GetActiveItem(i);
        if (item != null) {
          OnEquipItem(item, i);
        }
      }
    }

    private void OnEquipItem(Item item, int slotID)
    {
      if (!item.DominantItem)
        return;

      GunIcon.sprite = item.Icon;
    }

    protected override void OnUseConsumableItemIdentifier(Item item, IItemIdentifier itemIdentifier, int amount)
    {
      CurrentAmount.text = amount.ToString();
    }

    protected override void OnAdjustItemIdentifierAmount(IItemIdentifier itemIdentifier, int amount)
    {
      TotalAmount.text = amount.ToString();
    }
  }
}
