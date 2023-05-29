using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float SideSpeed = 1f;
    public Rigidbody rb;

    private bool isMoving = false;
    private bool isFinal = false;
    Animator anim;

    public static Vector3 currentPosition;

    public float jumpForce = 5f;        
    public float fowardForce = 2f;     
    private bool isJumping = false;




    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPosition = transform.position;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
            anim.SetBool("isMoving" ,isMoving);
            
        }   

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
            anim.SetBool("isMoving", isMoving);
        }

        if (isMoving)
        {
            Vector3 movement = Vector3.forward * speed * Time.deltaTime;

            
                Touch touch = Input.GetTouch(0);
                float touchDelta = touch.deltaPosition.x * Time.deltaTime * SideSpeed;
                Vector3 newPos = transform.position + movement + new Vector3(touchDelta, 0f, 0f);
                transform.position = newPos;
                currentPosition = transform.position;

                rb.MovePosition(transform.position + movement);
        }
       
        if(isFinal)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            currentPosition = transform.position;
            anim.SetBool("isMoving", isMoving);
        }
        
    }
            
            

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("jump") && !isJumping && !gameObject.CompareTag("body")) //karakterin z�plamas�
        {
            
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(Vector3.forward * fowardForce, ForceMode.Impulse); 
            
            isMoving= false;
            
        }

        if (other.CompareTag("LongJump") && !isJumping) //karakterin z�plamas�
        {

            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce * 2, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(Vector3.forward * fowardForce * 2, ForceMode.Impulse);
           
            isMoving= false;

        }

        if (other.CompareTag("Diamond")) //elmas toplanmas�
        {
            ScoreCounter.scoreValue++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("LastRun"))
        {
            isFinal = true;
            
           
        }
    }

}
