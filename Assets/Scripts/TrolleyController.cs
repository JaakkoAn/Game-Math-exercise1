using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;  // Import the UI namespace to work with sliders

public class TrolleyController : MonoBehaviour
{
    public Slider trolleySlider;  // Reference to the UI slider
    public float minX = -22f;     // Far limit for the trolley
    public float maxX = -10f;     // Near limit for the trolley
    public float yPosition = 39.5f;  // Fixed Y position for the trolley

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

        // Set the trolley's position, keeping Y constant
        transform.localPosition = new Vector3(newX, yPosition, transform.localPosition.z);
    }
}

