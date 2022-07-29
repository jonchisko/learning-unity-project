using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Waffle.CharacterSystem.MovementSystem
{
    public interface IMoveState
    {
        void OnEnter();
        void MoveLeft();
        void MoveRight();
        void SpecialAbility();
        void Jump();
        void Update();
    }
}

