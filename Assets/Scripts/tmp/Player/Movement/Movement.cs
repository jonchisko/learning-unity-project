using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Waffle.Player.Movement
{
    public class Movement : MonoBehaviour
    {
        private static MovementState idleState;
        private static MovementState runState;
        private static MovementState airState;

        private Character character;
        private MovementState currentState;

        // Start is called before the first frame update
        void Start()
        {
            Transform playerTransform = this.GetComponent<Transform>();
            character = new Character(playerTransform);
            currentState = idleState;
        }

        // Update is called once per frame
        void Update()
        {
            SetState();
        }

        private void SetState()
        {
            float movementSpeed = character.GetMovementSpeed();
            if (movementSpeed > 0.0f)
            {
                currentState = runState;
            }
            else if (Mathf.Abs(movementSpeed - 0.0f) < Mathf.Epsilon && character.GetGrounded())
            {
                currentState = idleState;
            }
            else
            {
                currentState = airState;
            }
        }

        public void Run(Vector2 direction)
        {
            currentState.Run(direction);
        }

        public void Jump()
        {
            currentState.Jump();
        }

        /*public MovementState GetCurrentState()
        {
            return this.currentState;
        }*/
    }
}
