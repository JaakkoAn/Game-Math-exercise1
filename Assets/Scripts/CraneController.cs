using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using GameMath.UI;

public class CraneController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public HoldableButton leftButton;
    public HoldableButton rightButton;

    void Update()
    {
        // Check for UI button input
        if (leftButton.IsHeldDown)
        {
            RotateCrane(-1);  // Rotate left
        }
        else if (rightButton.IsHeldDown)
        {
            RotateCrane(1);  // Rotate right
        }
        else
        {
            // Check for keyboard input (A & D or left/right arrow keys)
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                RotateCrane(horizontalInput);  // Rotate based on keyboard input
            }
        }
    }

    // Method to handle crane rotation
    void RotateCrane(float direction)
    {
        transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);
    }
}

