using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class flippingWeapon : MonoBehaviour
{

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
       
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0f;

            Vector3 weaponDirection = cursorPosition - transform.position;

            if (weaponDirection.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 0);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 0);
            }
        
    }
}