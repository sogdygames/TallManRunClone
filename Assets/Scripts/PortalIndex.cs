using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalIndex : MonoBehaviour
{
     public int index;

    public static float Increase = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (index == 0)
        {
            Vector3 scale = other.transform.localScale;
            scale.x += Increase * 2;

            Vector3 position = other.transform.position;
            float positionAdjustment = (scale.x - other.transform.localScale.x) / 2.0f;
            position.x += positionAdjustment;

            other.transform.localScale = scale;
            other.transform.position = position;

            Destroy(gameObject);
        }

        if (index == 1)
        {
            Vector3 scale = other.transform.localScale;
            scale.x -= Increase;

            Vector3 position = other.transform.position;
            float positionAdjustment = (scale.x + other.transform.localScale.x) / 2.0f;
            position.x -= positionAdjustment;

            other.transform.localScale = scale;
            other.transform.position = position;

            Destroy(gameObject);
        }

        if (index == 2)
        {
            Vector3 scale = other.transform.localScale;
            scale.y += Increase;

            Vector3 position = other.transform.position;
            float positionAdjustment = (scale.y - other.transform.localScale.y) / 2.0f;
            position.y += positionAdjustment;

            other.transform.localScale = scale;
            other.transform.position = position;

            Destroy(gameObject);
        }

        if (index == 3)
        {
            Vector3 scale = other.transform.localScale;
            scale.y -= Increase;

            Vector3 position = other.transform.position;
            float positionAdjustment = (scale.y + other.transform.localScale.y) / 2.0f;
            position.y -= positionAdjustment;

            other.transform.localScale = scale;
            other.transform.position = position;
            Destroy(gameObject);
        }

        if (index == 4)
        {
            Vector3 scale = other.transform.localScale;
            scale.y -= Increase;

            Vector3 position = other.transform.position;
            float positionAdjustment = (scale.y + other.transform.localScale.y) / 2.0f;
            position.y -= positionAdjustment;

            other.transform.localScale = scale;
            other.transform.position = position;
            
        }
    }
}
