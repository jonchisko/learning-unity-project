using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CharacterSystems.MovementSystems;

namespace Waffle.CharacterSystems
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private MovementSystem movementSystem;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                movementSystem.MoveLeft();
            }

            if (Input.GetKey(KeyCode.D))
            {
                movementSystem.MoveRight();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                movementSystem.Jump();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                
            }
        }
    }
}

