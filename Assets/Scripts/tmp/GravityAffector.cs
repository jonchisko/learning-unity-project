using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAffector : MonoBehaviour
{
    private readonly float gravity = 20.0f;
    private readonly float maxFallSpeed = 80.0f;

    [SerializeField]
    private Transform fallableTransform;
    private IFallable fallable;
    private float currentFallSpeed = 0.0f;

    private void Awake()
    {
        this.fallable = this.fallableTransform.GetComponent<IFallable>();
        if (fallable == null)
        {
            Debug.LogError(string.Format("{0} could not found IFallable!", this.ToString()));
        }

        this.currentFallSpeed = this.fallable.GetVerticalSpeed();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.currentFallSpeed = this.fallable.GetVerticalSpeed();
        if (!this.fallable.IsGrounded())
        {
            this.currentFallSpeed -= gravity * Time.deltaTime;
            this.currentFallSpeed = Mathf.Max(this.currentFallSpeed, -this.maxFallSpeed);
        } else
        {
            this.currentFallSpeed = 0.0f;
        }
        this.fallable.SetVerticalSpeed(this.currentFallSpeed);
    }
}
