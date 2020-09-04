using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Character //classe base de todo personagem no jogo.
{

    public GameObject characterPrefab;//prefab do character
    public CharacterStatus status;
    public string nameCharacter;//nome do character
    public float lifeCharacter;//vida do character
    public float lifeFullCharacter;//vida do character

    public void TakeLife(Character character, float value, int op)
    {
        if(op == 1)
        {
            if (characterPrefab.GetComponent<EnemyMovement>() != null)
            {
                if(characterPrefab.GetComponent<EnemyMovement>().inBattle == false)
                characterPrefab.GetComponent<EnemyMovement>().StartCoroutine(characterPrefab.GetComponent<EnemyMovement>().Chase());
            }
            if (characterPrefab.GetComponent<CrowScene>() != null)
            {
                
                characterPrefab.GetComponent<CrowScene>().DestroyCrow();
                return;

            }
            character.lifeCharacter -= value;
            if (character.lifeCharacter <= 0)
            {
                if(character.characterPrefab.GetComponent<QuestElement>() != null)
                {
                    character.characterPrefab.GetComponent<QuestElement>().CompleteRequest();
                }
                character.Dead(character.characterPrefab.GetComponent<Animator>());
                character.lifeCharacter = 0;
            }
            status.UpdateStatus(this);
        }
        else
        {
            character.lifeCharacter += value;
            if (character.lifeCharacter > character.lifeFullCharacter)
            {
                character.lifeCharacter = character.lifeFullCharacter;
            }
            status.UpdateStatus(this);
        }
    }

    public virtual void Dead(Animator anim)
    {
        anim.SetBool("Dead", true);
        if(anim.gameObject.GetComponent<CarterScene>()){
            Game.singleton.estadoMorto.Death();
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

public class WitchNecromancer : Character
{
    public float damage;//variavel que demonstra o dano da bruxa.
    public WitchNecromancer(string Name, float Life, float LifeFull, float Damage)//contrutor
    {
        nameCharacter = Name;
        lifeCharacter = Life;
        lifeFullCharacter = LifeFull;
        damage = Damage;
    }
}

public class Esqueleton : Character
{
    public float damage;//variavel que demonstra o dano da bruxa.
    public Esqueleton(string Name, float Life, float LifeFull, float Damage)//contrutor
    {
        nameCharacter = Name;
        lifeCharacter = Life;
        lifeFullCharacter = LifeFull;
        damage = Damage;
    }
}

public class WitchRanged : Character
{
    public float damage;//variavel que demonstra o dano da bruxa.
    public WitchRanged(string Name, float Life, float LifeFull, float Damage)//contrutor
    {
        nameCharacter = Name;
        lifeCharacter = Life;
        lifeFullCharacter = LifeFull;
        damage = Damage;
    }
}
public class Crow : Character
{
    public float damage;//variavel que demonstra o dano da bruxa.
    public Crow(string Name, float Life, float LifeFull, float Damage)//contrutor
    {
        nameCharacter = Name;
        lifeCharacter = Life;
        lifeFullCharacter = LifeFull;
        damage = Damage;
    }
}




