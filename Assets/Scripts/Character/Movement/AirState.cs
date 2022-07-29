using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CardSystems.Movement;
using Waffle.Physics;

namespace Waffle.CharacterSystem.MovementSystem
{
    public class AirState : IMoveState
    {
        private ObjectSpeed objectSpeed;
        private MovementStats movementStats;
        private Animator animator;
        private MovementSystem movementSystem;

        public AirState(MovementSystem movementSystem)
        {
            this.movementSystem = movementSystem;
            objectSpeed = movementSystem.GetObjectSpeed();
            movementStats = movementSystem.GetMovementStats();
            animator = movementSystem.GetAnimator();
        }

        public void OnEnter()
        {
            Debug.Log("Entering Air State");
            // set animation
            animator.SetBool("Grounded", false);
            animator.SetInteger("AnimState", 0);
        }

        public void Update()
        {
            animator.SetFloat("AirSpeedY", objectSpeed.GetVertical());
        }

        public void Jump()
        {
            Debug.Log("No jump in air state");
        }

        public void MoveLeft()
        {
            movementSystem.GetSpriteRenderer().flipX = true;

            float currentSpeed = objectSpeed.GetHorizontal();
            float desiredSpeed = -movementStats.GetMaxAirSpeed().getSpeedX();
            float maxSpeedChange = -movementStats.GetAirAcceleration().getSpeedX() * Time.deltaTime;

            if (currentSpeed > desiredSpeed)
            {
                currentSpeed = Mathf.Max(currentSpeed + maxSpeedChange, desiredSpeed);
            }
            objectSpeed.SetHorizontal(currentSpeed);
            animator.SetInteger("AnimState", 1);
        }

        public void MoveRight()
        {
            movementSystem.GetSpriteRenderer().flipX = false;

            float currentSpeed = objectSpeed.GetHorizontal();
            float desiredSpeed = movementStats.GetMaxAirSpeed().getSpeedX(); // since this is equal in both clases, this could be behind an interface and both states would just get a different object
            // then the logic code can eb moved into the abstract class state
            float maxSpeedChange = movementStats.GetAirAcceleration().getSpeedX() * Time.deltaTime;

            if (currentSpeed < desiredSpeed)
            {
                currentSpeed = Mathf.Min(currentSpeed + maxSpeedChange, desiredSpeed);
            }
            objectSpeed.SetHorizontal(currentSpeed);
            animator.SetInteger("AnimState", 1);
        }

        public void SpecialAbility()
        {
            if (!movementSystem.HasMovementAbility()) return;

            MovementAbility ability = movementSystem.GetMovementAbility();
            ability.Execute();
        }
    }
}

