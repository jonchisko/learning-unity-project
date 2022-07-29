using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Waffle.Physics
{
    [CreateAssetMenu(menuName = "Physics/MovementStats")]
    public class MovementStats : ScriptableObject
    {
        [System.Serializable]
        public struct Speed
        {
            [SerializeField]
            private float speedX;

            public Speed(float x)
            {
                speedX = x;
            }

            public float getSpeedX()
            {
                return speedX;
            }
        }

        [SerializeField]
        private Speed groundSpeed;
        [SerializeField]
        private Speed maxGroundSpeed;
        [SerializeField]
        private Speed airSpeed;
        [SerializeField]
        private Speed maxAirSpeed;
        [SerializeField]
        private float jumpForce;

        public Speed GetGroundSpeed()
        {
            return groundSpeed;
        }

        public Speed GetMaxGroundSpeed()
        {
            return maxGroundSpeed;
        }

        public Speed GetAirSpeed()
        {
            return airSpeed;
        }

        public Speed GetMaxAirSpeed()
        {
            return maxAirSpeed;
        }

        public float GetJumpForce()
        {
            return jumpForce;
        }
    }
}

