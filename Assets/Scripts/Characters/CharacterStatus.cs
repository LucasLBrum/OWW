using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    public Slider lifeSlider;
    public Text lifeText;

    public void UpdateStatus(Character character)
    {
        float someFloat = character.lifeCharacter;
        int someInt = (int)Mathf.Round(someFloat);

        lifeSlider.value = character.lifeCharacter;
        lifeText.text = someInt + "/" + character.lifeFullCharacter;
    }
}
