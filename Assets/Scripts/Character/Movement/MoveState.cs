using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Waffle.CharacterSystems.MovementSystems
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

