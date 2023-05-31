using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalIndex : MonoBehaviour
{
    public int index; //portallarý numaralandýrdým

    public float value = 0.1f;
    public GameObject character;
    public GameObject Head;

    public static CameraFollow cameraFollow;



    public float fowardForce = 10f;

    private void Start()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();

    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 width = other.transform.localScale;
        Vector3 length = other.transform.localPosition;

        if (other.CompareTag("body")) //Uzunluk 
        {
            if (index == 4)
            {
                length.y -= value;
                other.transform.localPosition = length;
                Destroy(gameObject);
            }

            if (index == 3)
            {
                length.y += value;
                other.transform.localPosition = length;
                Destroy(gameObject);
            }

            if (index == 2)
            {
                length.y *= 0.5f;
                other.transform.localPosition = length;
                Destroy(gameObject);
            }

            if (index == 0) //bariyer
            {
                length.y -= value * 2;
                other.transform.localPosition = length;

            }
        }

        
        else //genislik 
        {
            if (index == 1)
            {
                width.x += value;
                width.z += value;
                other.transform.localScale = width;
                Destroy(gameObject);
            }

        }

        if (length.y <= -0.2f) //karakterin ölmesi
        {
            Instantiate(Head, new Vector3(CharacterMovement.currentPosition.x, 3.7f, CharacterMovement.currentPosition.z), Quaternion.identity);

            Destroy(character);

            if (cameraFollow != null)
            {
                cameraFollow.StopFollowing();
            }

        }
    }


}
