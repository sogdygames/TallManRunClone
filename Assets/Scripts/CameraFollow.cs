using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    private Vector3 offset;
    public static bool isFollowing; 

    private void Start()
    {
        offset = transform.position - character.position;
        isFollowing = true; 
    }

    private void LateUpdate()
    {
        if (isFollowing)
            transform.position = character.position + offset;
    }

    
    public void StopFollowing()
    {
        isFollowing = false;
    }
}
