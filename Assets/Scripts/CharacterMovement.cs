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
    private bool onGround = false;
    Animator anim;

    public static Vector3 currentPosition;

    public float jumpForce = 5f;
    public float fowardForce = 2f;




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
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
            anim.SetBool("isMoving", false);
        }

        if (isMoving && onGround)
        {
            Vector3 movement = Vector3.forward * speed * Time.deltaTime;
            anim.SetBool("isMoving", true);

            Touch touch = Input.GetTouch(0);
            float touchDelta = touch.deltaPosition.x * Time.deltaTime * SideSpeed;
            Vector3 newPos = transform.position + movement + new Vector3(touchDelta, 0f, 0f);
            transform.position = newPos;
            currentPosition = transform.position;

            rb.MovePosition(transform.position + movement);
        }

        if (isFinal)
        {
            isMoving = false;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            currentPosition = transform.position;

            anim.SetBool("isMoving", true);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("LastRun"))
        {
            onGround = true;
            anim.SetTrigger("notJump");
            anim.speed = 1f;

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("jump") && !gameObject.CompareTag("body") && onGround) //karakterin ziplamasi
        {
            isMoving = false;
            onGround = false;

            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(Vector3.forward * fowardForce, ForceMode.Impulse);

            anim.SetBool("isMoving", false);
            anim.speed = 0.65f;
            anim.SetTrigger("isJump");

        }

        if (other.CompareTag("LongJump") && !gameObject.CompareTag("body") && onGround) //karakterin ziplamasi
        {
            isMoving = false;
            onGround = false;

            GetComponent<Rigidbody>().AddForce(2 * jumpForce * Vector3.up, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(2 * fowardForce * Vector3.forward, ForceMode.Impulse);

            anim.SetBool("isMoving", false);
            anim.SetTrigger("isJump");

            anim.speed = 0.3f;

        }

        if (other.CompareTag("Diamond")) //elmas toplanmasi
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


