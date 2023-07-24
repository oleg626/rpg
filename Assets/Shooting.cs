using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject shootPrefab;
    public Transform shootPFTransform;
    public bool canShoot;
    private float timer;
    public float shootCD;
     void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

     void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0 , rotZ);

        if(!canShoot)
        {
            timer += Time.deltaTime;
            if(timer > shootCD)
            {
                canShoot = true;
                timer = 0;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            canShoot = false;
            Instantiate(shootPrefab, shootPFTransform.position, Quaternion.identity);
        }
    }

}
