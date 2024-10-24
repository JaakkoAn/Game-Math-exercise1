using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class CraneTargeting : MonoBehaviour
{
    public Transform crane;         // Reference to the crane's rotating part
    public float rotationSpeed = 50f; // Speed of crane rotation
    private bool isRotating = false;
    private float targetRotationAngle;
    private float rotationAmount;

    void Update()
    {
        // Detect mouse click
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Start rotating the crane if any object is clicked
                isRotating = true;

                // Set the target rotation to 180 degrees from the current angle
                targetRotationAngle = 180f;
                rotationAmount = 0f; // Reset the amount rotated so far
            }
        }

        // Rotate the crane if in rotating state
        if (isRotating)
        {
            RotateCrane180Degrees();
        }
    }

    void RotateCrane180Degrees()
    {
        // Rotate the crane by small steps towards 180 degrees
        float step = rotationSpeed * Time.deltaTime;

        if (rotationAmount < targetRotationAngle) // If we haven't completed the 180-degree rotation
        {
            crane.Rotate(0f, step, 0f);  // Rotate by the step amount
            rotationAmount += step;      // Keep track of how much we've rotated
        }
        else
        {
            // Stop rotating once 180 degrees is reached
            isRotating = false;
        }
    }
}



