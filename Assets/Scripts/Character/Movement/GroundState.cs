using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waffle.MovementSystem
{
    public class GroundState : IMoveState
    {
        private MovementSystem movementSystem;

        public GroundState(MovementSystem movementSystem)
        {
            this.movementSystem = movementSystem;
        }

        public void OnEnter()
        {
            throw new System.NotImplementedException();
        }

        public void Jump()
        {
            throw new System.NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new System.NotImplementedException();
        }

        public void MoveRight()
        {
            throw new System.NotImplementedException();
        }

        public void SpecialAbility()
        {
            throw new System.NotImplementedException();
        }
    }
}


