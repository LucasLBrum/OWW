using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : CharacterStatus
{
    public Character enemy;

    void Start()
    {
        enemy = GetComponent<CharacterScene>().thisCharacter;
        enemy.status = this;
        lifeSlider.maxValue = enemy.lifeFullCharacter;//troco os valores do componente slider para atualizar o hud.
        lifeSlider.value = enemy.lifeFullCharacter;
        lifeText.text = enemy.lifeCharacter + "/" + enemy.lifeFullCharacter;
    }

    private void Update()
    {
        if(Camera.main != null)
        lifeSlider.transform.LookAt(Camera.main.transform);
    }
}
