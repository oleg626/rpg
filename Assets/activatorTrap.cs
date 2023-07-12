using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.PlayerSettings;

public class activatorTrap : MonoBehaviour
{
    public bool isInrange;
    public UnityEvent interAct;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInrange)
        {

            interAct.Invoke();
            

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            isInrange = true;
            Debug.Log("Привет");
        }
    }

   
}
