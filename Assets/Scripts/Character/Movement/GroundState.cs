using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CardSystems.Movement;
using Waffle.Physics;

namespace Waffle.MovementSystem
{
    public class GroundState : IMoveState
    {
        private MovementSystem movementSystem;

        public GroundState(MovementSystem movementSystem)
        {
            this.movementSystem = movementSystem;
        }

        public void OnEnter()
        {
            // set animation
        }

        public void Update()
        {

        }

        public void Jump()
        {
            ObjectSpeed objectSpeed = movementSystem.GetObjectSpeed();
            MovementStats movementStats = movementSystem.GetMovementStats();

            objectSpeed.SetVertical(movementStats.GetJumpForce());
        }

        public void MoveLeft()
        {
            ObjectSpeed objectSpeed = movementSystem.GetObjectSpeed();
            MovementStats movementStats= movementSystem.GetMovementStats();
            objectSpeed.SetHorizontal(-movementStats.GetGroundSpeed().getSpeedX());
        }

        public void MoveRight()
        {
            ObjectSpeed objectSpeed = movementSystem.GetObjectSpeed();
            MovementStats movementStats = movementSystem.GetMovementStats();
            objectSpeed.SetHorizontal(movementStats.GetGroundSpeed().getSpeedX());
        }

        public void SpecialAbility()
        {
            if (!movementSystem.HasMovementAbility()) return;
            
            MovementAbility ability = movementSystem.GetMovementAbility();
            ability.Execute();
        }
    }
}


