using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.Physics;
using Waffle.CardSystems.Movement;

namespace Waffle.MovementSystem
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
            Debug.Log(objectSpeed.GetVertical());
        }

        private void StateChanger()
        {
            float y = objectSpeed.GetVertical();
            if (Mathf.Abs(y - 0) <= Mathf.Epsilon)
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

