using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Waffle.Physics
{
    public class ObjectSpeed : MonoBehaviour
    {
        [SerializeField]
        private Transform objectTransform;

        private Vector2 speed = Vector2.zero;


        private void Awake()
        {
            Debug.Assert(objectTransform != null, "objectTransform is null in ObjectSpeed");
        }

        void FixedUpdate()
        {
            Vector2 change = Vector2.right * speed.x + Vector2.up * speed.y;
            objectTransform.Translate(change * Time.deltaTime);
        }

        public void SetHorizontal(float value)
        {
            speed.x = value;
        }

        public void SetVertical(float value)
        {
            speed.y = value;
        }

        public float GetHorizontal()
        {
            return speed.x;
        }

        public float GetVertical()
        {
            return speed.y;
        }
    }
}

