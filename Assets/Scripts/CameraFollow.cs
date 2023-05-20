using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;  
    private Vector3 offset;      

    private void Start()
    {
        
        offset = transform.position - character.position;
    }

    private void LateUpdate()
    {
        
        transform.position = character.position + offset;
    }
}
