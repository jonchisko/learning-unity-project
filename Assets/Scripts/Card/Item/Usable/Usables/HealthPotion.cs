using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CharacterSystems;

namespace Waffle.CardSystems.Item.Usable.Usables
{
    public class HealthPotion : Usable
    {
        public HealthPotion(PlayerSystem playerSystem, UsableInfo usableInfo) : base(playerSystem, usableInfo)
        {
        }

        public override void Use()
        {
            // should inject some info into the prefab stats
            throw new System.NotImplementedException();
        }
    }
}
