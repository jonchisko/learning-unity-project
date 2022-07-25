using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Waffle.Player.Movement
{
    public class Character
    {
        private Transform playerTransform;
        private Vector2 movementDirection = Vector2.zero;
        private float movementSpeed = 0.0f;
        private bool grounded = true;

        public Character(Transform playerTransform)
        {
            this.playerTransform = playerTransform;
        }

        public Transform GetPlayerTransform()
        {
            return this.playerTransform;
        }

        public Vector2 GetMovementDirection()
        {
            return this.movementDirection;
        }

        public float GetMovementSpeed()
        {
            return this.movementSpeed;
        }

        public bool GetGrounded()
        {
            return this.grounded;
        }

        public void SetMovementDirection(Vector2 movementDirection)
        {
            this.movementDirection = movementDirection;
        }

        public void SetMovementSpeed(float movementSpeed)
        {
            this.movementSpeed = movementSpeed;
        }

        public void SetGrounded(bool grounded)
        {
            this.grounded = grounded;
        }
    }
}