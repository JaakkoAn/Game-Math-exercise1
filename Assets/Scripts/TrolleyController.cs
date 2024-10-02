using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class TrolleyController : MonoBehaviour
{
    public Slider trolleySlider;  // Reference to the UI slider
    public Transform crane;       // Reference to the crane transform
    public float minX = -22f;     // Far limit for the trolley
    public float maxX = -10f;     // Near limit for the trolley
    public float yPosition = 39.5f;  // Fixed Y position for the trolley
    public float zOffset = 0f;    // Z offset relative to the crane

    void Start()
    {
        // Set the slider's min and max values based on the trolley's limits
        trolleySlider.minValue = 0f;
        trolleySlider.maxValue = 1f;

        // Optional: Set the initial position of the slider (starting at the far limit)
        trolleySlider.value = 0f;
    }

    void Update()
    {
        // Map the slider's value (0 to 1) to the trolley's X position (minX to maxX)
        float newX = Mathf.Lerp(minX, maxX, trolleySlider.value);

        // Calculate the world position of the trolley based on the crane's rotation
        Vector3 relativePosition = new Vector3(newX, yPosition, zOffset);
        transform.position = crane.TransformPoint(relativePosition);

        // Ensure the trolley's rotation matches the crane's rotation
        // Only update the Y rotation so the trolley aligns with the crane but doesn't tilt
        Quaternion craneRotation = Quaternion.Euler(0f, crane.eulerAngles.y, 0f);
        transform.rotation = craneRotation;
    }
}



