using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public CharacterSelectionData characterDB;
    public TextMeshProUGUI nameText;
    public SpriteRenderer characterSprite;

    private int selectedOption = 0;
    void Start()
    {
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= characterDB.CharacterCount) 
        {
           selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
    }
    public void BackOption()
    {
        selectedOption--;
        if(selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter(int selectedOption)
    {
        Characters charaters = characterDB.GetCharacter(selectedOption);
        characterSprite.sprite = charaters.characterSprite;
        nameText.text = charaters.characterName;
    }
}
