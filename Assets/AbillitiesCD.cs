using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbillitiesCD : MonoBehaviour
{
    public Image abillityImage1;
    public float cooldown1 = 5f;
    bool isCoolDown = false;
    public KeyCode abillity1;
  
    // Start is called before the first frame update
    void Start()
    {
        abillityImage1.fillAmount = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Abillity1();
    }

     void Abillity1()
    {
        if(Input.GetKey(abillity1) && isCoolDown == false)
        {
            isCoolDown = true;
            abillityImage1.fillAmount = 1;

        }
        if (isCoolDown)
        {
            abillityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if(abillityImage1.fillAmount <=0)
            {
                abillityImage1.fillAmount = 0;
                isCoolDown = false;
            }
        }
    }
}
