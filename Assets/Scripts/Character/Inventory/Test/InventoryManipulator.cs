using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Waffle.CardSystems.Item.Usable;
using Waffle.CardSystems.Item.Usable.Usables;

namespace Waffle.CharacterSystems.InventorySystems
{
    public class InventoryManipulator : MonoBehaviour
    {
        [SerializeField]
        private PlayerSystem playerSystem;
        [SerializeField]
        private UsableInfo potionInfo;
        [SerializeField]
        private UsableInfo swordInfo;

        private IInventorySystem inventorySystem;
        private Usable potion;
        private Usable sword;

        // Start is called before the first frame update
        void Start()
        {
            potion = new HealthPotion(playerSystem, potionInfo);
            sword = new Sword(playerSystem, swordInfo);
            inventorySystem = playerSystem.GetInventorySystem();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                inventorySystem.AddPotion(potion);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                inventorySystem.AddWeapon(sword);
            }
        }
    }
}

