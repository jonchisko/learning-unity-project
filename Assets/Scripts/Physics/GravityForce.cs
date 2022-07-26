using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.PlatformSystems;


namespace Waffle.Physics
{
    public class GravityForce : MonoBehaviour
    {
        [SerializeField]
        private GravityInfo gravityInfo;
        [SerializeField]
        private Transform characterTransform; 
        [SerializeField]
        private ObjectSpeed objectSpeed;

        private bool isGrounded = true;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void FixedUpdate()
        {
            if (isGrounded)
            {
                objectSpeed.SetVertical(0);
                return;
            }

            float updatedSpeed = objectSpeed.GetVertical() + gravityInfo.GetGravityAcceleration() * Time.deltaTime;
            updatedSpeed = Mathf.Clamp(updatedSpeed, 0, gravityInfo.GetMaxGravitySpeed());
            objectSpeed.SetVertical(updatedSpeed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(PlatformTags.PlatformFloorTag))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(PlatformTags.PlatformFloorTag))
            {
                isGrounded = false;
            }
        }
    }
}

