using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waffle.Physics
{
    [CreateAssetMenu(menuName = "Physics/GravityInfo")]
    public class GravityInfo : ScriptableObject
    {
        [SerializeField]
        private float gravityAcceleration = 1.0f;
        [SerializeField]
        private float maxGravitySpeed = 20.0f;

        public float GetGravityAcceleration()
        {
            return gravityAcceleration;
        }

        public float GetMaxGravitySpeed()
        {
            return maxGravitySpeed;
        }
    }
}

