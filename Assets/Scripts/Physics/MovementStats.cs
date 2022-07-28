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
        private Speed airSpeed;

        public Speed GetGroundSpeed()
        {
            return groundSpeed;
        }

        public Speed GetAirSpeed()
        {
            return airSpeed;
        }
    }
}

