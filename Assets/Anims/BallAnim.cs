using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnim : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Move");
        }
    }
}
