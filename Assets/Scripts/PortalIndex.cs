using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalIndex : MonoBehaviour
{
     public int index;
    
    public static float Increase = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 scale = other.transform.localScale;

        if (other.CompareTag("body")) //Uzunluk 
        {


            if (index == 2)
            {
                scale.y += Increase;
                other.transform.localScale = scale;
                Destroy(gameObject);
            }

            if (index == 3)
            {
                scale.y -= Increase;
                other.transform.localScale = scale;
                Destroy(gameObject);
            }

            if (index == 4) //bariyer
            {
                scale.y -= Increase;
                other.transform.localScale = scale;
            }
        }

        else //genislik 
        {
            if (index == 0)
            {
                scale.x += Increase * 2; 
                other.transform.localScale = scale;
                Destroy(gameObject);
            }

            if (index == 1)
            {
                scale.x -= Increase;
                other.transform.localScale = scale;
                Destroy(gameObject);
            }
        }
    }
}
