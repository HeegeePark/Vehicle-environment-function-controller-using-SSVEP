using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowControll : MonoBehaviour
{
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            animator.SetTrigger("goUp");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("goDown");
        }

    }

}

