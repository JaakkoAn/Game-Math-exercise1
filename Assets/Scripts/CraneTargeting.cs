using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneTargeting : MonoBehaviour
{
    public Transform crane;         // Reference to the crane's rotating part
    public Transform concreteStack; // Reference to the concrete stack (target)
    public float rotationSpeed = 50f; // Speed of crane rotation
    private bool isRotating = false;
    private float targetAngle;

    void Update()
    {
        // Detect mouse click
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the concrete stack was clicked
                if (hit.transform == concreteStack)
                {
                    // Start rotating the crane
                    isRotating = true;

                    // Calculate direction to the concrete stack, flatten the Y axis
                    Vector3 directionToStack = (concreteStack.position - crane.position);
                    directionToStack.y = 0f; // Ignore the vertical difference

                    // Calculate the signed angle between crane's forward and the stack
                    targetAngle = Vector3.SignedAngle(crane.forward, directionToStack, Vector3.up);
                }
            }
        }

        // Rotate the crane if it is rotating
        if (isRotating)
        {
            RotateCraneTowardsTarget();
        }
    }

    void RotateCraneTowardsTarget()
    {
        // Smoothly rotate the crane towards the target angle
        float step = rotationSpeed * Time.deltaTime;

        // Check if the target angle is sufficiently small to stop rotating
        if (Mathf.Abs(targetAngle) > 0.5f) // Stopping threshold
        {
            // Rotate the crane based on the sign of the target angle
            float rotationAmount = Mathf.Sign(targetAngle) * step;
            crane.Rotate(0f, rotationAmount, 0f);

            // Reduce the target angle by the amount rotated
            targetAngle -= rotationAmount;
        }
        else
        {
            // Stop rotating once close enough
            isRotating = false;
        }
    }
}











