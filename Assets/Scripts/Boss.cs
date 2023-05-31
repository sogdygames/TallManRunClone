using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraFollow.isFollowing == false)
        {
            Anim.SetBool("win", true);
        }
    }
}
