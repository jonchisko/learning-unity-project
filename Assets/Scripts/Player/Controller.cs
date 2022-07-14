using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour, IFallable
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private MovementStats movementStats;

    private float speed = 0.0f;
    private float verticalSpeed = 0.0f;
    private float jumpAcceleration = 500.0f;
    private bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        ProcessInput();
        ProcessJump();
    }

    private void ProcessInput()
    {
        Vector2 direction = Vector2.left;
        float acceleration = movementStats.GetAcceleration();
        float deacceleration = movementStats.GetDeacceleration();
        float maxSpeed = movementStats.GetMaxSpeed();

        if (Input.GetKey(KeyCode.A))
        {
            this.speed += acceleration * Time.deltaTime;
            this.speed = Mathf.Clamp(this.speed, -maxSpeed, maxSpeed);
        } else if (Input.GetKey(KeyCode.D))
        {
            this.speed -= acceleration * Time.deltaTime;
            this.speed = Mathf.Clamp(this.speed, -maxSpeed, maxSpeed);
        } else
        {
            if (this.speed > deacceleration * Time.deltaTime)
            {
                this.speed -= deacceleration * Time.deltaTime;
            } else if (this.speed < -deacceleration * Time.deltaTime)
            {
                this.speed += deacceleration * Time.deltaTime;
            } else
            {
                this.speed = 0.0f;
            }
        }
        
        Debug.Log(string.Format("{0}, speed: {1}", this.ToString(), this.speed));

        playerTransform.Translate(this.speed * direction);
    }

    private void ProcessJump()
    {
        if (Input.GetKey(KeyCode.Space) && this.grounded)
        {
            this.verticalSpeed += jumpAcceleration * Time.deltaTime;
        }
        playerTransform.Translate(this.verticalSpeed * Time.deltaTime * Vector2.up);
    }

    public bool IsGrounded()
    {
        return this.grounded;
    }

    public void SetGrounded(bool grounded)
    {
        this.grounded = grounded;
    }

    public float GetVerticalSpeed()
    {
        return this.verticalSpeed;
    }
    public void SetVerticalSpeed(float verticalSpeed)
    {
        this.verticalSpeed = verticalSpeed;
    }
}
