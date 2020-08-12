using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    public Image vidaImage;
    public Image staminaImage;
    public Text vidaText;
    public bool regen;


    public void UpdateUI(float value, float valueMax, Image image)
    {
        image.rectTransform.sizeDelta = new Vector2(value / valueMax * 159, 20);
    }

    public void TakeValueAndUpdate(float value)
    {
        Player.singleton.carterScene.carter.lifeCharacter -= value;
        UpdateUI(Player.singleton.carterScene.carter.lifeCharacter, Player.singleton.carterScene.carter.lifeFullCharacter, vidaImage);
        if (Player.singleton.carterScene.carter.lifeCharacter <= 0)
        {
            Player.singleton.carterScene.GetComponent<Animator>().Play("Death", 0);
        }
    }

    public IEnumerator RegenStamina(float value, float time)
    {
        regen = true;
        while (Player.singleton.carterScene. carter.stamina < Player.singleton.carterScene.carter.staminaFull)
        {
            Player.singleton.carterScene.carter.stamina += value;
            Debug.Log(Player.singleton.carterScene.carter.stamina);
            UpdateUI(Player.singleton.carterScene.carter.stamina, Player.singleton.carterScene.carter.staminaFull, staminaImage);
            yield return new WaitForSeconds(3);
        }
        regen = false;
        yield return null;
    }
}
