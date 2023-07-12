using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{

    public float timeToLive = .1f;
    public float floatSpeed = 800;
    public TextMeshProUGUI textMesh;
    
    
    public Vector3 floatDirection = new Vector3(0, 1, 0);
    
    RectTransform rTransform;
    Color startingColor;

    Text dp;
    float timeElapsed = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        startingColor = textMesh.color;
        rTransform = GetComponent<RectTransform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        timeElapsed += Time.deltaTime;
        rTransform.position += floatDirection  * floatSpeed *  Time.deltaTime;

        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (timeElapsed / timeToLive));
        
        
        if (timeElapsed > timeToLive)
        {
            Destroy(gameObject);
        }

    }
}
