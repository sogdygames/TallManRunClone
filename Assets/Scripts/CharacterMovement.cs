using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;  // Speed of character movement

    private bool isMoving = false;
    private bool isMovingLeft = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;        
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }


        

        

        if (isMoving)
        {
            
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Input.mousePosition.x < Screen.width / 2)
            {

                isMovingLeft = true;
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {

                isMovingLeft = false;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
}
