using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CardSystems.Item.Usable;
using Waffle.Common;

namespace Waffle.CharacterSystems.InventorySystems
{
    public class PlayerHand
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
            equipable.transform.SetParent(handObject.transform, false);
        }

        public void UnsetEquipableToHand()
        {
            equipableReference = null;
            ClearCurrentUsable();
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

        private void ClearCurrentUsable()
        {
            if (currentUsable == null) return;

            currentUsable = null;
        }
    }
}


