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
        private float previousVerticalSpeed;

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
            float speed = objectSpeed.GetHorizontal() - movementStats.GetAirSpeed().getSpeedX() * Time.deltaTime;
            objectSpeed.SetHorizontal(Mathf.Max(speed, -movementStats.GetMaxAirSpeed().getSpeedX()));
        }

        public void MoveRight()
        {
            movementSystem.GetSpriteRenderer().flipX = false;
            float speed = objectSpeed.GetHorizontal() + movementStats.GetAirSpeed().getSpeedX() * Time.deltaTime;
            objectSpeed.SetHorizontal(Mathf.Min(speed, movementStats.GetMaxAirSpeed().getSpeedX()));
        }

        public void SpecialAbility()
        {
            if (!movementSystem.HasMovementAbility()) return;

            MovementAbility ability = movementSystem.GetMovementAbility();
            ability.Execute();
        }
    }
}

