using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject abillityObj;
    public KeyCode skillKey;
   
    private Vector3 mousePos;

    void Update()
    {
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        if (Input.GetKeyDown(skillKey))
        {
            
                Instantiate(abillityObj, mousePos, Quaternion.identity);
            


        }

    }
   
}
