using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CharacterSystems.MovementSystems;
using Waffle.CharacterSystems.InventorySystems;

namespace Waffle.CharacterSystems
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private MovementSystem movementSystem;

        [SerializeField]
        private PlayerHand playerHand;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                movementSystem.MoveLeft();
            }

            if (Input.GetKey(KeyCode.D))
            {
                movementSystem.MoveRight();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                movementSystem.Jump();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movementSystem.SpecialAbility();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerHand.UsePotion();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerHand.EquipWeapon();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                playerHand.PutToInventory();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerHand.UseEquiped();
            }
        }
    }
}

