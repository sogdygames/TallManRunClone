using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float SideSpeed = 1f;
    public Rigidbody rb;

    private bool isMoving = false;

    public static Vector3 currentPosition;

    public float jumpForce = 5f;        
    public float fowardForce = 2f;     
    private bool isJumping = false;




    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPosition = transform.position;
    }

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
            Vector3 movement = Vector3.forward * speed * Time.deltaTime;

            
                Touch touch = Input.GetTouch(0);
                float touchDelta = touch.deltaPosition.x * Time.deltaTime * SideSpeed;
                Vector3 newPos = transform.position + movement + new Vector3(touchDelta, 0f, 0f);
                transform.position = newPos;
                currentPosition = newPos;

                rb.MovePosition(transform.position + movement);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("jump") && !isJumping) //karakterin zýplamasý
        {
            
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(Vector3.forward * fowardForce, ForceMode.Impulse); 
            
            isMoving= false;
            
        }

        if (other.CompareTag("LongJump") && !isJumping) //karakterin zýplamasý
        {

            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce * 2, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(Vector3.forward * fowardForce * 2, ForceMode.Impulse);
           
            isMoving= false;

        }

        if (other.CompareTag("Diamond")) //elmas toplanmasý
        {
            ScoreCounter.scoreValue++;
            Destroy(other.gameObject);
        }
    }

}
