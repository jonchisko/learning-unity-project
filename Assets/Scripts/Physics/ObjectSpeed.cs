using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Waffle.Physics
{
    public class ObjectSpeed : MonoBehaviour
    {
        [SerializeField]
        private Transform objectTransform;

        private float xSpeed = 0;
        private float ySpeed = 0;


        private void Awake()
        {
            Debug.Assert(objectTransform != null, "objectTransform is null in ObjectSpeed");
        }

        void FixedUpdate()
        {
            Vector2 change = (Vector2.right * xSpeed + Vector2.up * ySpeed) * Time.deltaTime;
            objectTransform.Translate(change);
        }

        public void SetHorizontal(float value)
        {
            xSpeed = value;
        }

        public void SetVertical(float value)
        {
            ySpeed = value;
        }

        public float GetHorizontal()
        {
            return xSpeed;
        }

        public float GetVertical()
        {
            return ySpeed;
        }
    }
}

