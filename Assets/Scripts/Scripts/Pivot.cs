using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{

    public GameObject myPlayer;
    public GameObject myWeapon;
    Vector2 movement;
    bool lookRight = true;
    private void FixedUpdate()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        int minAngle = -90;
        int maxAngle = 90;
        

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if(movement.x < 0)
        {
            lookRight = false;
        }else if(movement.x > 0)
        {
            lookRight = true;
        }

        if (lookRight == false)
        {
          
            myWeapon.GetComponent<SpriteRenderer>().flipY = true;
            minAngle = 90;
            
            if(difference.x < 0)
            {
                if(rotationZ < 90 && rotationZ >= 0)
                {
                    rotationZ = 90;
                }
                if(rotationZ > -90 && rotationZ <= 0)
                {
                    rotationZ = -90;
                }              
                
                transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z - 180);
            }
        }
        else
        {
            myWeapon.GetComponent<SpriteRenderer>().flipY = false;
            if (difference.x > 0)
            {
                
                rotationZ = Mathf.Min(rotationZ, maxAngle);
                rotationZ = Mathf.Max(rotationZ, minAngle);
                transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }

        

        


       

       

        //if (rotationZ < -90 || rotationZ > 90)
        //{



        //    if (myPlayer.transform.eulerAngles.y == 0)
        //    {


        //        transform.localRotation = Quaternion.Euler(90, 0, -rotationZ);


        //    }
        //    else if (myPlayer.transform.eulerAngles.y == 90)
        //    {


        //        transform.localRotation = Quaternion.Euler(90, 90, -rotationZ);


        //    }

        //}

    }

}