using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class CableController : MonoBehaviour
{
    public Transform trolley;   // Reference to the trolley
    public Transform hook;      // Reference to the hook (to get the cable length)

    public float cableYOffset = -2f;  // Distance from trolley to the start of the cable
    public float hookYOffset = -10f;  // Distance from trolley to the hook (adjust as needed)

    void Update()
    {
        // Set the cable's position relative to the trolley
        Vector3 cablePosition = new Vector3(trolley.position.x, trolley.position.y + cableYOffset, trolley.position.z);
        transform.position = cablePosition;

        // Stretch the cable to reach the hook (scale the cable based on distance to hook)
        float cableLength = Vector3.Distance(transform.position, hook.position);
        transform.localScale = new Vector3(transform.localScale.x, cableLength, transform.localScale.z);
    }
}


