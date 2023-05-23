using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalIndex : MonoBehaviour
{
     public int index; //portalları numaralandırdım
    
    public static float Increase = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 width = other.transform.localScale;
        Vector3 length = other.transform.localPosition;

        if (other.CompareTag("body")) //Uzunluk 
        {


            if (index == 75)
            {
                length.y += Increase * 7.5f ;
                other.transform.localPosition = length;
                Destroy(gameObject);
            }

            if (index == 50)
            {
                length.y += Increase * 5.0f;
                other.transform.localPosition = length;
                Destroy(gameObject);
            }

            if (index == 2)
            {
                length.y *= Increase * 5f;
                other.transform.localPosition = length;
                Destroy(gameObject);
            }

            if (index == 0) //bariyer
            {
                length.y -= Increase * 4;
                other.transform.localPosition = length;
            }
        }

        else //genislik 
        {
            if (index == 15)
            {
                width.x += Increase * 1.5f; 
                other.transform.localScale = width;
                Destroy(gameObject);
            }
    
        }

        if (length.y <=0)
        {
            Debug.Log("Öldün");
        }
    }

    
}
