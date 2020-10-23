using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarterStatus : CharacterStatus
{
    public bool regen;
    public Slider staminaSlider;
    public Text staminaText;
    public Carter carter;
    public GameObject panelDamage;

    

    float staminaPrice = 0.01f;
    public float StaminaPrice
    {
        get
        {
            return staminaPrice;
        }
    }
    
    float staminaRegen = 0.05f;
    public float StaminaRegen
    {
        get
        {
            return staminaRegen;
        }
    }

    private void Start()
    {
        carter = GetComponent<CarterScene>().carter; //pego a refêrencia do personagem em questão.
        carter.status = this;
        lifeSlider.maxValue = carter.lifeFullCharacter;//troco os valores do componente slider para atualizar o hud.
        lifeSlider.value = carter.lifeFullCharacter;
        lifeText.text = carter.lifeCharacter + "/" + carter.lifeFullCharacter;

        staminaSlider.maxValue = carter.staminaFull;//troco os valores do componente slider para atualizar o hud.
        staminaSlider.value = carter.staminaFull;
        staminaText.text = carter.stamina + "/" + carter.staminaFull;
    }

    public IEnumerator RegenStamina()
    {
        regen = true;
        yield return new WaitForSeconds(1);
        while (carter.stamina < carter.staminaFull && regen == true)
        {
            Player.singleton.carterScene.carter.stamina += staminaRegen;
            UpdateStamina();

            yield return new WaitForSeconds(0.1f);
        }
        regen = false;
        yield return null;
    }

    public void UpdateStamina()
    {
        float someFloat = carter.stamina;
        int someInt = (int)Mathf.Round(someFloat);

        staminaSlider.value = carter.stamina;
        staminaText.text = someInt + "/" + carter.staminaFull;
    }

    public void TakeStamina(float value)
    {
        carter.TakeStamina(value, 1);
        UpdateStamina();
    }

    public IEnumerator FeedBackDamage()
    {
        float time = 3;
        panelDamage.SetActive(true);
        while(time > 1)
        {
            yield return new WaitForSeconds(1f);
            time--;
        }
        panelDamage.SetActive(false);
        yield return null;
    }
}
