using Waffle.CardSystems.Item.Usable;
using Waffle.CardSystems.Item.Usable.Usables;
using Waffle.Common;

namespace Waffle.CharacterSystems.InventorySystems
{
    public interface IInventorySystem
    {
        Optional<Usable> UsePotion();
        Optional<Usable> UseWeapon();
        void AddPotion(Usable potion);
        void AddWeapon(Usable weapon);

        void RegisterToInventoryChange(IObserver<UsableHolder> observer);
        void DeregisterToInventoryChange(IObserver<UsableHolder> observer);
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
        private event InventoryEventHandler onInventoryChange;

        private UsableHolder inventoryPotionBag = new UsableHolder();
        private UsableHolder inventoryWeaponBag = new UsableHolder();

        public InventorySystem() { }

        public void AddPotion(Usable potion)
        {
            AddToInventory(inventoryPotionBag, potion);
        }

        public void AddWeapon(Usable weapon)
        {
            AddToInventory(inventoryWeaponBag, weapon);
        }

        public Optional<Usable> UsePotion()
        {
            Optional<Usable> potion = GetFromInventory(inventoryPotionBag);
            return potion;
        }

        public Optional<Usable> UseWeapon()
        {
            Optional<Usable> weapon = GetFromInventory(inventoryWeaponBag);
            return weapon;
        }

        public void RegisterToInventoryChange(IObserver<UsableHolder> observer)
        {
            onInventoryChange += observer.Notify;
        }

        public void DeregisterToInventoryChange(IObserver<UsableHolder> observer)
        {
            onInventoryChange -= observer.Notify;
        }

        private void AddToInventory(UsableHolder holder, Usable usable)
        {
            holder.SetUsable(usable);
            holder.SetAmount(holder.GetAmount() + 1);
            onInventoryChange?.Invoke(holder);
        }

        private Optional<Usable> GetFromInventory(UsableHolder holder)
        {
            Usable usableToReturn = holder.GetUsable();
            if (holder.GetAmount() > 0) holder.SetAmount(holder.GetAmount() - 1);
            onInventoryChange?.Invoke(holder);
            if (holder.GetAmount() == 0)
            {
                holder.SetUsable(null);
            }
            
            return usableToReturn;
        }
    }
}

