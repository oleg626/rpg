using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbillitiesCD : MonoBehaviour
{
    public GameObject player;
    private SkillSystem skillSystem;

    public GameObject ability1;
    public GameObject ability2;
    public GameObject ability3;
    public GameObject ability4;
    private List<GameObject> abilities;
    private List<Image> abilitiesIcons;
    private int skillsNumber = 0;
    void Start()
    {
        abilities = new List<GameObject>();
        abilities.Add(ability1);
        abilities.Add(ability2);
        abilities.Add(ability3);
        abilities.Add(ability4);

        skillSystem = player.GetComponent<SkillSystem>();
        abilitiesIcons = new List<Image>();
        skillsNumber = skillSystem.getNumberOfSkills();

        for (int i = 0; i < skillsNumber; i++) 
        {
            abilities[i].GetComponent<Image>().sprite = skillSystem.getSkillImage(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0;i < abilitiesIcons.Count; i++)
        {
            //int cd = skillSystem.getSkillCd(i);
            //Debug.Log("Abitilities CD: skill " + i + " has cd of " + cd + " sec");
            /*if (cd > 0)
            {
                abilitiesIcons[i].fillAmount = cd;
            }
            else
            {
                abilitiesIcons[i].fillAmount = 0;
            }*/
        }
    }
}
