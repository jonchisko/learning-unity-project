using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFallable
{
    bool IsGrounded();
    void SetGrounded(bool grounded);
    float GetVerticalSpeed();
    void SetVerticalSpeed(float verticalSpeed);
}
