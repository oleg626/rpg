using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootDescription : MonoBehaviour
{
    public Canvas lootDesr;
     void Start()
    {
        lootDesr.enabled = false;
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        lootDesr.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        lootDesr.enabled = false;
    }
}
