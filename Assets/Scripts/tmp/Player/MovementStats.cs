using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Movement/Stats")]
public class MovementStats : ScriptableObject
{
    [SerializeField]
    private float maxSpeed = 5.0f;
    [SerializeField]
    private float acceleration = 0.2f;
    [SerializeField]
    private float deacceleration = 0.4f;

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

    public float GetAcceleration()
    {
        return acceleration;
    }

    public float GetDeacceleration()
    {
        return deacceleration;
    }
}
