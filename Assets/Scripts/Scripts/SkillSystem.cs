using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.UI.Image;
using Debug = UnityEngine.Debug;

public class SkillSystem : MonoBehaviour
{
    public LayerMask mapLayer;
    public List<SkillData> m_skillsData;
    public GameObject skillPrefab;
    public GameObject greenCursor;
    public GameObject redCursor;
    private Vector3 mousePos;
  
    private int m_currentSkill = -1;
    private Dictionary<KeyCode, int> m_keyToIndex;

    public int getNumberOfSkills()
    {
        return m_skillsData.Count;
    }

    public int getSkillCd(int index)
    {
        return m_skillsData[index].getCooldownLeft();
    }

    public Sprite getSkillImage(int index)
    {
        return m_skillsData[index].image;
    }

     void Start()
     {
        greenCursor.GetComponent<Renderer>().enabled = false;
        redCursor.GetComponent<Renderer>().enabled = false;

        m_keyToIndex = new Dictionary<KeyCode, int>
        {
            { KeyCode.Alpha1, 0 },
            { KeyCode.Alpha2, 1 },
            { KeyCode.Alpha3, 2 },
            { KeyCode.Alpha4, 3 }
        };

        foreach(SkillData data in m_skillsData) 
        { 
            data.cdReset();
        }
     }

    void Update()
    {
        updateCursor();
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
                               Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        

        if (m_skillsData == null)
            return;

        if (m_currentSkill != -1 && Input.GetMouseButton(0))
        {
            GameObject skillObject = Instantiate(skillPrefab, mousePos, Quaternion.identity);
            Skill createdSkill = skillObject.GetComponent<Skill>();
            createdSkill.m_data = m_skillsData[m_currentSkill];
            createdSkill.use();
            m_skillsData[m_currentSkill].use();
            m_currentSkill = -1;
            Cursor.visible = true;
            greenCursor.GetComponent<Renderer>().enabled = false;
        }

        foreach (KeyCode key in m_keyToIndex.Keys)
        {
            int index = m_keyToIndex[key];
            if (index >= m_skillsData.Count)
                return;
            
            if (Input.GetKey(key) && !m_skillsData[index].isOnCooldown() && m_currentSkill == -1)
            {
                if (m_skillsData[index].melee)
                {
                    // implement melee
                    return;
                }
                else
                {
                    m_currentSkill = index;
                    Cursor.visible = false;
                    greenCursor.GetComponent<Renderer>().enabled = true;
                }
            }
        }
        

        
    }

    void updateCursor()
    {
     
        if (m_currentSkill == -1)
        {
            redCursor.GetComponent<Renderer>().enabled = false;
            greenCursor.GetComponent<Renderer>().enabled = false;
            return;
        }
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                               Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        bool inRange = (gameObject.transform.position - mousePos).sqrMagnitude < MathF.Pow(m_skillsData[m_currentSkill].attackRange, 2);
        // Perform the raycast from the origin to the target point
        Vector3 direction = mousePos - gameObject.transform.position;
        float distance = direction.magnitude;
        Ray ray = new Ray(gameObject.transform.position, direction.normalized);

        // Check if there is an obstacle along the ray's path
        bool collision = Physics.Raycast(ray, distance, mapLayer);
        

        if (!inRange || collision)
        {
            redCursor.GetComponent<Renderer>().enabled = true;
            greenCursor.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            redCursor.GetComponent<Renderer>().enabled = false;
            greenCursor.GetComponent<Renderer>().enabled = true;
        }
        greenCursor.transform.position = mousePos;
        redCursor.transform.position = mousePos;
    }
}
