using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject abillityObj;
    public KeyCode skillKey;
    public GameObject greenCursor;
    public float coolDown = 5f;
    float nextSkillUse;
    public bool isActive = false;
    private Vector3 mousePos;
    private KeyCode cancelSkill = KeyCode.Escape;
     void Start()
    {
        greenCursor.GetComponent<Renderer>().enabled = false;   
    }
    void Update()
    {
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        if (Time.time > nextSkillUse)
        {
            
            if (Input.GetKeyDown(skillKey))
            {
                greenCursor.GetComponent <Renderer>().enabled = true;
                Cursor.visible = false;
                isActive = true;
            }
        }
        if(Input.GetKey(cancelSkill))
        {
            greenCursor.GetComponent<Renderer>().enabled = false;
            isActive = false;
            
        }
        if (Input.GetMouseButton(0) && isActive)
        {
            UseSkill();
            nextSkillUse = Time.time + coolDown;
        }

        


    }
    void UseSkill()
    {
        
        
            
                
                greenCursor.GetComponent<Renderer>().enabled = false;
                Cursor.visible = true;
                Instantiate(abillityObj, mousePos, Quaternion.identity);
                isActive = false;
            
        
    }
   
}
