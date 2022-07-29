using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CardSystems.Movement;
using Waffle.Physics;

namespace Waffle.CharacterSystem.MovementSystem
{
    public class GroundState : IMoveState
    {
        private ObjectSpeed objectSpeed;
        private MovementStats movementStats;
        private Animator animator;
        private MovementSystem movementSystem;

        public GroundState(MovementSystem movementSystem)
        {
            this.movementSystem = movementSystem;
            objectSpeed = movementSystem.GetObjectSpeed();
            movementStats = movementSystem.GetMovementStats();
            animator = movementSystem.GetAnimator();
        }

        public void OnEnter()
        {
            Debug.Log("Entering Ground State");
            // set animation
            animator.SetBool("Grounded", true);
            animator.SetFloat("AirSpeedY", objectSpeed.GetVertical());
        }

        public void Update()
        {
            if (Mathf.Abs(objectSpeed.GetHorizontal() - 0.0f) < Mathf.Epsilon)
            {
                animator.SetInteger("AnimState", 0);
            }
        }

        public void Jump()
        {
            Debug.Log("JUMP!");
            animator.SetTrigger("Jump");
            objectSpeed.SetVertical(movementStats.GetJumpForce());
        }

        public void MoveLeft()
        {
            movementSystem.GetSpriteRenderer().flipX = true;

            float currentSpeed = objectSpeed.GetHorizontal();
            float desiredSpeed = -movementStats.GetMaxGroundSpeed().getSpeedX();
            float maxSpeedChange = -movementStats.GetGroundAcceleration().getSpeedX() * Time.deltaTime;
            
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
            float desiredSpeed = movementStats.GetMaxGroundSpeed().getSpeedX();
            float maxSpeedChange = movementStats.GetGroundAcceleration().getSpeedX() * Time.deltaTime;

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


