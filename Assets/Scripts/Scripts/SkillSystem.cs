using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class SkillSystem : MonoBehaviour
{
    public List<SkillData> m_skillsData;
    public GameObject skillPrefab;
    public GameObject greenCursor;
    public GameObject redCursor;
    private Vector3 mousePos;
    private KeyCode cancelSkill = KeyCode.Escape;
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

        m_keyToIndex = new Dictionary<KeyCode, int>
        {
            { KeyCode.Alpha1, 0 },
            { KeyCode.Alpha2, 1 },
            { KeyCode.Alpha3, 2 },
            { KeyCode.Alpha4, 3 }
        };
     }

    void Update()
    {
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
                               Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        if (m_skillsData == null)
            return;

        foreach (KeyCode key in m_keyToIndex.Keys)
        {
            if (Input.GetKey(key))
            {
                int index = m_keyToIndex[key];
                if (index < m_skillsData.Count /*&& !m_skillsData[index].isOnCooldown()*/)
                {
                    Debug.Log("Skill " + m_keyToIndex[key] + " is used");
                    GameObject skillObject = Instantiate(skillPrefab, mousePos, Quaternion.identity);
                    Skill createdSkill = skillObject.GetComponent<Skill>();
                    createdSkill.m_data = m_skillsData[m_keyToIndex[key]];
                    createdSkill.use();
                    m_skillsData[index].use();
                }
            }
        }   
    }
}
