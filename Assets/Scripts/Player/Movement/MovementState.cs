using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waffle.Player.Movement
{
    public class MovementState
    {
        protected Character character;

        public MovementState(Character character)
        {
            this.character = character;
        }

        public virtual void Run(Vector2 direction)
        {
            Debug.LogWarning("Run not implemented for this state.");
        }
        public virtual void Jump()
        {
            Debug.LogWarning("Jump not implemented for this state.");
        }

        public virtual void Update()
        {
            float speed = character.GetMovementSpeed();
            if (speed > 0)
            {
                speed -= 2.0f;
                character.SetMovementSpeed(speed < 0.0f ? 0.0f : speed);
            }
        }
    }

    class IdleState : MovementState
    {
        public IdleState(Character character) : base(character)
        {
        }

        override public void Run(Vector2 direction)
        {
            Transform transform = character.GetPlayerTransform();
            transform.Translate(direction * character.GetMovementSpeed());
        }

        public override void Jump()
        {

        }
    }

    class RunState : MovementState
    {
        public RunState(Character character) : base(character)
        {
        }

        override public void Run(Vector2 direction)
        {
            Transform transform = character.GetPlayerTransform();
            transform.Translate(direction * character.GetMovementSpeed());
        }

        public override void Jump()
        {

        }
    }

    class AirState : MovementState
    {
        public AirState(Character character) : base(character)
        {
        }

        override public void Run(Vector2 direction)
        {

        }

        public override void Jump()
        {

        }
    }
}


