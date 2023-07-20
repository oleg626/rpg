using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCursor : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = worldPosition;
    }
}
