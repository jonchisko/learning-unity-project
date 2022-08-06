using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CardSystems.Item.Usable;

namespace Waffle.CharacterSystems.InventorySystems
{
    public interface IInventorySystem
    {
        Usable UsePotion();
        Usable UseWeapon();
        void AddPotion(Usable potion);
        void AddWeapon(Usable weapon);
    }

    public class UsableHolder
    {
        private Usable usable = null;
        private int amount = 0;

        public UsableHolder() { }

        public Usable GetUsable()
        {
            return usable;
        }

        public int GetAmount()
        {
            return amount;
        }

        public void SetUsable(Usable usable)
        {
            this.usable = usable;
        }

        public void SetAmount(int amount)
        {
            this.amount = amount;
        }
    }

    public class InventorySystem : IInventorySystem
    {
        public delegate void InventoryEventHandler(UsableHolder usableHolder);
        private event InventoryEventHandler onPotionChange;
        private event InventoryEventHandler onWeaponChange;

        private Usable inventoryPotionBag;
        private Usable inventoryWeaponBag;

        public InventorySystem()
        {

        }

        public void AddPotion(Usable potion)
        {
            throw new System.NotImplementedException();
        }

        public void AddWeapon(Usable weapon)
        {
            throw new System.NotImplementedException();
        }

        public Usable UsePotion()
        {
            throw new System.NotImplementedException();
        }

        public Usable UseWeapon()
        {
            throw new System.NotImplementedException();
        }
    }
}

