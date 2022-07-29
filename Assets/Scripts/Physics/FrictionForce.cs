using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waffle.Physics
{
    //rather name as deacceleration or something, unless you actuall wana do friction
    public class FrictionForce : MonoBehaviour
    {
        [SerializeField]
        private ObjectSpeed objectSpeed;
        [SerializeField]
        private FrictionStats frictionStats;
        

        // Start is called before the first frame update
        void Start()
        {
            Debug.Assert(objectSpeed != null);
            Debug.Assert(frictionStats != null);
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalSpeed = objectSpeed.GetHorizontal();
            float friction = frictionStats.GetFriction();
            if (horizontalSpeed > 0 && horizontalSpeed - friction * Time.deltaTime > 0)
            {
                objectSpeed.SetHorizontal(horizontalSpeed - friction * Time.deltaTime);
            } else if (horizontalSpeed < 0 && horizontalSpeed + friction * Time.deltaTime < 0)
            {
                objectSpeed.SetHorizontal(horizontalSpeed + friction * Time.deltaTime);
            } else {
                objectSpeed.SetHorizontal(0);
            }
        }
    }
}

