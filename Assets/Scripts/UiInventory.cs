using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Waffle.CardSystems.Item.Usable;
using Waffle.CharacterSystems;
using Waffle.CharacterSystems.InventorySystems;
using Waffle.Common;
using TMPro;

public class UiInventory : MonoBehaviour, IObserver<UsableHolder>
{
    [SerializeField]
    Sprite emptySprite;

    [SerializeField]
    Image potionImage;

    [SerializeField]
    Image weaponImage;

    [SerializeField]
    TextMeshProUGUI amountPotion;

    [SerializeField]
    TextMeshProUGUI amountWeapon;

    [SerializeField]
    PlayerSystem playerSystem;
    private IInventorySystem inventorySystem;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting UI inventory");
        inventorySystem = playerSystem.GetInventorySystem();
        potionImage.sprite = emptySprite;
        weaponImage.sprite = emptySprite;
        amountPotion.text = $"{0}";
        amountWeapon.text = $"{0}";

        inventorySystem.RegisterToInventoryChange(this);
    }

    private void OnDestroy()
    {
        inventorySystem.DeregisterToInventoryChange(this);
    }

    public void Notify(UsableHolder subject)
    {
        UsableInfo usableInfo = subject.GetUsable().GetUsableInfo();
        if (subject.GetAmount() > 0)
        {
            SetCorrectSprite(usableInfo, usableInfo.GetUsableIcon());
        } else
        {
            SetCorrectSprite(usableInfo, emptySprite);
        }
        SetCorrectTest(usableInfo, subject.GetAmount());
    }

    private void SetCorrectSprite(UsableInfo usableInfo, Sprite sprite)
    {
        switch (usableInfo.GetUsableType())
        {
            case Waffle.CardSystems.Item.Usable.Usables.UsableType.HEALTH_POTION: potionImage.sprite = sprite; break;
            case Waffle.CardSystems.Item.Usable.Usables.UsableType.SWORD: weaponImage.sprite = sprite; break;
            default: Debug.LogError("Usable type " + usableInfo.GetUsableType() + ", does not exist!"); break;
        }
    }

    private void SetCorrectTest(UsableInfo usableInfo, int amount)
    {
        switch (usableInfo.GetUsableType())
        {
            case Waffle.CardSystems.Item.Usable.Usables.UsableType.HEALTH_POTION: amountPotion.text = $"{amount}"; break;
            case Waffle.CardSystems.Item.Usable.Usables.UsableType.SWORD: amountWeapon.text = $"{amount}"; break;
            default: Debug.LogError("Usable type " + usableInfo.GetUsableType() + ", does not exist!"); break;
        }
    }
}
