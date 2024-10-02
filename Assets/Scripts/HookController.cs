using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public Transform cable;  // Reference to the cable
    public float hookYOffset = -2f;  // Adjust this value to place the hook correctly below the cable

    void Update()
    {
        // Set the hook's position at the end of the cable
        Vector3 hookPosition = new Vector3(cable.position.x, cable.position.y + hookYOffset, cable.position.z);
        transform.position = hookPosition;
    }
}

