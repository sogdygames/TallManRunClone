using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;  // Reference to the character's transform
    private Vector3 offset;      // Offset between camera and character

    private void Start()
    {
        // Calculate the initial offset between camera and character
        offset = transform.position - character.position;
    }

    private void LateUpdate()
    {
        // Update the camera's position to follow the character
        transform.position = character.position + offset;
    }
}
