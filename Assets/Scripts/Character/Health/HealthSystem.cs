using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waffle.CharacterSystems.HealthSystems
{
    public interface ILiveable
    {
        void Heal(int heal);
        void Damage(int damage);
    }


    public class HealthSystem : ILiveable
    {
        private HealthModel model;

        public HealthSystem(HealthStats stats)
        {
            this.model = new HealthModel(stats.GetMaxHealth());
        }
        
        public void Damage(int damage)
        {
            int diff = model.GetCurrentHealth() - damage;
            model.SetCurrentHealth(diff <= 0 ? 0 : diff);
        }

        public void Heal(int heal)
        {
            int diff = model.GetCurrentHealth() + heal;
            model.SetCurrentHealth(diff >= model.GetMaxHealth() ? model.GetMaxHealth() : diff);
        }

        public HealthModel GetHealthModel()
        {
            return model;
        }
    }
}

