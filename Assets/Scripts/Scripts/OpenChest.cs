using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;

    public void OpenChestF()
    {
       
        if (!isOpen)
        {
            isOpen = true;
            animator.SetBool("IsOpen", isOpen);
            Destroy(gameObject.GetComponentInChildren<Canvas>());
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
       
    }
}
