using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CardSystems.Movement;
using Waffle.Physics;

namespace Waffle.MovementSystem
{
    public class AirState : IMoveState
    {
        private MovementSystem movementSystem;

        public AirState(MovementSystem movementSystem)
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
            Debug.Log("No jump in air state");
        }

        public void MoveLeft()
        {
            ObjectSpeed objectSpeed = movementSystem.GetObjectSpeed();
            MovementStats movementStats = movementSystem.GetMovementStats();
            objectSpeed.SetHorizontal(-movementStats.GetAirSpeed().getSpeedX());
        }

        public void MoveRight()
        {
            ObjectSpeed objectSpeed = movementSystem.GetObjectSpeed();
            MovementStats movementStats = movementSystem.GetMovementStats();
            objectSpeed.SetHorizontal(movementStats.GetAirSpeed().getSpeedX());
        }

        public void SpecialAbility()
        {
            if (!movementSystem.HasMovementAbility()) return;

            MovementAbility ability = movementSystem.GetMovementAbility();
            ability.Execute();
        }
    }
}

