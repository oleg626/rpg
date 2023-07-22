using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject cooldown1;
    public GameObject cooldown2;
    public GameObject cooldown3;
    public GameObject cooldown4;

    private List<GameObject> abilities;
    private List<GameObject> cooldowns;
    private int skillsNumber = 0;
    void Start()
    {
        abilities = new List<GameObject>
        {
            ability1,
            ability2,
            ability3,
            ability4
        };

        cooldowns = new List<GameObject>
        {
            cooldown1,
            cooldown2,
            cooldown3,
            cooldown4
        };

        skillSystem = player.GetComponent<SkillSystem>();
        skillsNumber = skillSystem.getNumberOfSkills();

        for (int i = 0; i < skillsNumber; i++) 
        {
            abilities[i].GetComponent<Image>().sprite = skillSystem.getSkillImage(i);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        for (int i = 0; i < skillsNumber; i++)
        {
            int cd = skillSystem.getSkillCd(i);
            string cdText = "";
            if (cd > 0) 
                cdText = cd.ToString();
            cooldowns[i].GetComponent<TextMeshProUGUI>().text = cdText;
        }
    }
}
