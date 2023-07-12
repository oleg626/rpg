using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInrange;
    public KeyCode interactionKey;
    public UnityEvent interactAction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInrange)
        {
            if(Input.GetKeyDown(interactionKey))
            {
                interactAction.Invoke();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInrange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInrange = false;
        }
    }
}
