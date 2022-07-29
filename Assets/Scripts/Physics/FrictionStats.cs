using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waffle.Physics
{
    [CreateAssetMenu(menuName = "Physics/FrictionStats")]
    public class FrictionStats : ScriptableObject
    {
        [SerializeField]
        private float friction;

        public float GetFriction()
        {
            return friction;
        }
    }
}
