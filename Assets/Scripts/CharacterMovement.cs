using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    private bool isMoving = false;

    public float widthIncrease = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wide"))
        {
            Vector3 scale = transform.localScale;
            scale.x += widthIncrease;

            Vector3 position = transform.position;
            float positionAdjustment = (scale.x - transform.localScale.x) / 2.0f;
            position.x += positionAdjustment;

            transform.localScale = scale;
            transform.position = position;

            Destroy(other.gameObject);
        }

        if (other.CompareTag("length"))
        {
            Vector3 scale = transform.localScale;
            scale.y += widthIncrease;

            Vector3 position = transform.position;
            float positionAdjustment = (scale.y - transform.localScale.y) / 2.0f;
            position.y += positionAdjustment;

            transform.localScale = scale;
            transform.position = position;

            Destroy(other.gameObject);
        }

        if (other.CompareTag("barrier"))
        {
            Vector3 scale = transform.localScale;
            scale.y -= widthIncrease;

            Vector3 position = transform.position;
            float positionAdjustment = (scale.y + transform.localScale.y) / 2.0f;
            position.y -= positionAdjustment;

            transform.localScale = scale;
            transform.position = position;
        }
    }

}
