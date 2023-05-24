using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    private bool isMoving = false;
    public GameObject body;

    public float jumpForce = 5f;        
    public float sidewayForce = 2f;     
    private bool isJumping = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 Body = body.transform.localScale;

        

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
                Vector3 movement = Vector3.forward * speed * Time.deltaTime;

                if (Input.mousePosition.x < Screen.width / 2)
                {

                    movement += Vector3.left * speed * Time.deltaTime;
                }
                else
                {

                    movement += Vector3.right * speed * Time.deltaTime;
                }

                rb.MovePosition(transform.position + movement);
            }

        
    }

    private void OnTriggerEnter(Collider other) //karakterin zýplamasý
    {
        if (other.CompareTag("jump") && !isJumping)
        {
            
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(Vector3.forward * sidewayForce, ForceMode.Impulse); 
            isJumping = true;
            isMoving= false;
            
        }
    }

}
