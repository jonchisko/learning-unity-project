using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CardSystems.Item.Usable;
using Waffle.Common;

namespace Waffle.CharacterSystems.InventorySystems
{
    public class PlayerHand : MonoBehaviour
    {
        private GameObject handObject;
        private GameObject equipableReference = null;
        private IInventorySystem inventorySystem;
        private Usable currentUsable = null;
        

        public PlayerHand(IInventorySystem inventorySystem, GameObject handObject)
        {
            this.inventorySystem = inventorySystem;
            this.handObject = handObject;
        }

        public void SetEquipableToHand(GameObject equipable)
        {
            if (equipable == equipableReference) return;

            equipableReference = equipable;
            Instantiate(equipable, handObject.transform);
            equipable.transform.SetParent(handObject.transform, false);
        }

        public void UnsetEquipableToHand()
        {
            Destroy(equipableReference);
            equipableReference = null;
        }

        public void UsePotion()
        {
            Optional<Usable> usable = inventorySystem.UsePotion();
            if (!usable.HasValue) return;

            usable.Value.Use();
        } 

        public void EquipWeapon()
        {
            Optional<Usable> usable = inventorySystem.UseWeapon();
            if (!usable.HasValue) return;

            currentUsable = usable.Value;
        }

        public void UnequipWeapon()
        {
            if (currentUsable == null) return;

            currentUsable = null;
        }

        public void PutToInventory()
        {
            if (currentUsable == null) return;

            inventorySystem.AddWeapon(currentUsable);
            currentUsable = null;
        }

        public void UseEquiped()
        {
            if (currentUsable == null) return;

            currentUsable.Use();
        }
    }
}


