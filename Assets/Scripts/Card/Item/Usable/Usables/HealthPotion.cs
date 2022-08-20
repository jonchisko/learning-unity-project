using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CharacterSystems;
using Waffle.CharacterSystems.HealthSystems;

namespace Waffle.CardSystems.Item.Usable.Usables
{
    public class HealthPotion : Usable
    {
        public HealthPotion(PlayerSystem playerSystem, UsableInfo usableInfo) : base(playerSystem, usableInfo)
        {

        }

        public override void Use()
        {
            ILiveable liveable = base.playerSystem.GetHealthSystem();
            if (liveable == null) return;

            Debug.Log(this + " (health potion), Use() with amount: " + base.usableInfo.GetAmount());
            liveable.Heal(base.usableInfo.GetAmount());   
        }
    }
}

