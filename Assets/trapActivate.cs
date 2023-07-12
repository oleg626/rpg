using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapActivate : MonoBehaviour
{
    public bool isActive;
    public Animator animator;

    public void activateTrap()
    {
        if(!isActive)
        {
            isActive = true;
            animator.SetBool("isActive", isActive);

        }
    }
}
