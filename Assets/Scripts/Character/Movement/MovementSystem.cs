using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.Physics;
using Waffle.CardSystems.Movement;

namespace Waffle.MovementSystem
{
    public class MovementSystem : MonoBehaviour, IMoveState
    {
        [SerializeField]
        private MovementStats movementStats;
        [SerializeField]
        private Animator animatorController;
        [SerializeField]
        private ObjectSpeed objectSpeed;

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
        }

        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            StateChanger();
        }

        private void StateChanger()
        {

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

        public void OnEnter()
        {
            currentState.OnEnter();
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
    }
}

