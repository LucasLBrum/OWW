using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Character //classe base de todo personagem no jogo.
{

    public GameObject characterPrefab;//prefab do character
    public string nameCharacter;//nome do character
    public float lifeCharacter;//vida do character
    public float lifeFullCharacter;//vida do character
    public Animator anim;

    public void TakeLife(Character character, float value, int op)
    {
        if(op == 1)
        {
            character.lifeCharacter -= value;
            
            if (character.lifeCharacter <= 0)
            {
                character.anim.SetBool("isDead", true);
                character.lifeCharacter = 0;
            }
        }
        else
        {
            character.lifeCharacter += value;
            if (character.lifeCharacter > character.lifeFullCharacter)
            {
                character.lifeCharacter = character.lifeFullCharacter;
            }
        }
    }
}

public class Carter : Character//classe do personagem principal que tem varios diferenciais dos demais personagens.
{
    public float stamina;//variavel que controla a stamina do personagem, assim controlando a quantida de pulos e corridas que ele pode dar com determinado valor da mesma.
    public float staminaFull;//variavel que controla a stamina do personagem, assim controlando a quantida de pulos e corridas que ele pode dar com determinado valor da mesma.
    public float staminaRegen;
    public Inventory inventory;//inventario do persoangem.
    public Carter(string Name, float Life, float LifeFull, float Stamina, float StaminaFull, float StaminaRegen) //contrutor
    {
        nameCharacter = Name;
        lifeCharacter = Life;
        lifeFullCharacter = LifeFull;
        stamina = Stamina;
        staminaFull = StaminaFull;
        staminaRegen = StaminaRegen;
    }

    public void TakeStamina(float value, int op)
    {
        switch(op)
        {
            case 1:
                stamina -= value;
                if (stamina < 0)
                    stamina = 0;
                break;

            case 2:
                stamina += value;
                if (stamina > staminaFull)
                    stamina = staminaFull;
                break;
        }
    }
}

public class Witch : Character//classe da bruxa que tem varios diferenciais dos demais personagens.
{
    public float damage;//variavel que demonstra o dano da bruxa.
    public Witch(string Name, float Life, float LifeFull, float Damage)//contrutor
    {
        nameCharacter = Name;
        lifeCharacter = Life;
        lifeFullCharacter = LifeFull;
        damage = Damage;
    }
}
