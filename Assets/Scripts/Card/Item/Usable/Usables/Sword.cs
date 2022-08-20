using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CharacterSystems;
using Waffle.CharacterSystems.InventorySystems;

namespace Waffle.CardSystems.Item.Usable.Usables
{
    public class Sword : Usable
    {
        private PlayerHand playerHand;
        private SwordObject swordObject;
        private int counter = 0;

        public Sword(PlayerSystem playerSystem, UsableInfo usableInfo) : base(playerSystem, usableInfo)
        {
            playerHand = playerSystem.GetPlayerHand();
        }

        public override void Use()
        {
            if (swordObject == null)
            {
                swordObject = Object.Instantiate(base.usableInfo.GetIngamePrefab().GetComponent<SwordObject>());
                swordObject.SetDamage(base.usableInfo.GetAmount());
                playerHand.SetEquipableToHand(swordObject.gameObject);
            } else
            {
                swordObject.FireTrigger();
                counter++;
            }

            if (counter == base.usableInfo.GetDuration())
            {
                playerHand.UnsetEquipableToHand();
                Object.Destroy(swordObject.gameObject);
                swordObject = null;
                counter = 0;
            }
        }
    }
}

