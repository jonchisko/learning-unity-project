using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Waffle.CharacterSystems.HealthSystems
{
    public class HealthModel
    {
        public delegate void HealthModelEvent(HealthModel model);
        public HealthModelEvent onHealthChange;

        private int currentHealth;
        private int maxHealth;

        public HealthModel(int maxHealth)
        {
            currentHealth = maxHealth;
            this.maxHealth = maxHealth;
        }

        public int GetCurrentHealth()
        {
            return currentHealth;
        }

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        public void SetCurrentHealth(int value)
        {
            Debug.Assert(value >= 0 && value <= maxHealth, "HealthModel - currentHealth lower than 0 or larger than maxhp");

            currentHealth = value;
            onHealthChange?.Invoke(this);
        }

        public void SetMaxHealth(int value)
        {
            // we could set to 0 ;)
            Debug.Assert(value >= 0 && value >= currentHealth, "HealthModel - maxHealth lower than 0 or smaller than currenthp");

            maxHealth = value;
            onHealthChange?.Invoke(this);
        }
    }
}


