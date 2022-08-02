using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.Physics;
using Waffle.CardSystems.Movement;

namespace Waffle.CharacterSystems.MovementSystems
{
    public class MovementSystem : MonoBehaviour
    {
        [SerializeField]
        private MovementStats movementStats;
        [SerializeField]
        private Animator animatorController;
        [SerializeField]
        private ObjectSpeed objectSpeed;
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private GravityForce gravityForce;

        private IMoveState groundState;
        private IMoveState airState;
        private IMoveState currentState;

        private MovementAbility movementAbility;

        private void Awake()
        {
            groundState = new GroundState(this);
            airState = new AirState(this);
            currentState = groundState;

            Debug.Assert(movementStats != null);
            Debug.Assert(animatorController != null);
            Debug.Assert(objectSpeed != null);
            Debug.Assert(spriteRenderer != null);
            Debug.Assert(gravityForce != null);
        }

        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            StateChanger();
            currentState.Update();
        }

        private void StateChanger()
        {
            if (gravityForce.IsGrounded())
            {
                // grounded 
                if (currentState == groundState)
                {
                    return;
                }

                currentState = groundState;
                currentState.OnEnter();
            } else
            {
                // aired
                if (currentState == airState)
                {
                    return;
                }

                currentState = airState;
                currentState.OnEnter();
            }

        }

        public void Jump()
        {
            currentState.Jump();
        }

        public void MoveLeft()
        {
            currentState.MoveLeft();
        }

        public void MoveRight()
        {
            currentState.MoveRight();
        }

        public void SpecialAbility()
        {
            currentState.SpecialAbility();
        }

        public Animator GetAnimator()
        {
            return animatorController;
        }

        public ObjectSpeed GetObjectSpeed()
        {
            return objectSpeed;
        }

        public bool HasMovementAbility()
        {
            return movementStats != null;
        }

        public MovementAbility GetMovementAbility()
        {
            return movementAbility;
        }

        public MovementStats GetMovementStats()
        {
            return movementStats;
        }

        public SpriteRenderer GetSpriteRenderer()
        {
            return spriteRenderer;
        }
    }
}

