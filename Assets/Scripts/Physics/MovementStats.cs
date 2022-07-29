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
        private Speed groundAcceleration;
        [SerializeField]
        private Speed maxGroundSpeed;
        [SerializeField]
        private Speed airAcceleration;
        [SerializeField]
        private Speed maxAirSpeed;
        [SerializeField]
        private float jumpForce;

        public Speed GetGroundAcceleration()
        {
            return groundAcceleration;
        }

        public Speed GetMaxGroundSpeed()
        {
            return maxGroundSpeed;
        }

        public Speed GetAirAcceleration()
        {
            return airAcceleration;
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

