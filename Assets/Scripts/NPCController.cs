using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Animator animator;

    public bool idle;
    public bool sit;
    public bool talk;
    public bool dance;
    public bool sleep;

    void Start()
    {
        if (sit)
        { animator.SetBool("sit", true); }

        if (talk)
        { animator.SetBool("talk", true); }

        if (dance)
        { animator.SetBool("dance", true); }

        if (sleep)
        { animator.SetBool("sleep", true); }
    }

}
